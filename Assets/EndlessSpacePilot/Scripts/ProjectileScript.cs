using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour{

    public float durationInSeconds = 3f;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update(){

    }

    IEnumerator DestroySelf(){
        yield return new WaitForSeconds(durationInSeconds);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Sou:" + (CompareTag("EnemyProjectile") ? "EnemyProjectile" : CompareTag("PlayerProjectile") ? "PlayerProjectile" : CompareTag("Player") ? "Player" : CompareTag("Enemy") ? "Enemy" : "Não sei o que sou :C"));
        print("Colidi em:" +  (collision.CompareTag("EnemyProjectile") ? "EnemyProjectile" : collision.CompareTag("PlayerProjectile") ? "PlayerProjectile" : collision.CompareTag("Player") ? "Player" : collision.CompareTag("Enemy") ? "Enemy" : "Não sei o que sou :C"));
        if (collision.CompareTag("Player") && CompareTag("EnemyProjectile"))
        {
            Destroy(this.gameObject);
            collision.GetComponent<PlayerScript>().TakeDamage();
        }
        if (collision.CompareTag("Enemy") && CompareTag("PlayerProjectile"))
        {
            collision.GetComponent<EnemyScript>().TakeDamage();
            Destroy(this.gameObject);
        }
    }

}
