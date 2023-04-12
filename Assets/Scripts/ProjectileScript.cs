using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour{

    public float durationInSeconds = 3f;
    public GameObject explosion;

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
        if (collision.CompareTag("Player") && CompareTag("EnemyProjectile"))
        {
            Destroy(this.gameObject);
            if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
            collision.GetComponent<PlayerScript>().TakeDamage();
        }
        if (collision.CompareTag("Enemy") && CompareTag("PlayerProjectile"))
        {
            collision.GetComponent<EnemyScript>().TakeDamage();
            if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
