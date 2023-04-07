using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour{

    public float speed = 1;
    public Vector2 screenLimit;
    public GameObject projectile;
    public Transform[] shootPositions;
    public Vector2 shootDirection = new(1,0);
    public float shootCD = .5f;
    public float shootSpeed = 300;
    float shootTimer = 0;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        shootTimer += Time.deltaTime;
        Moviment();
        Shoot();
    }

    void Shoot(){
        if (Input.GetAxisRaw("Jump") != 0 && shootTimer >= shootCD){
            for(int i = 0; i < shootPositions.Length; i++){
                print("Atirando com o : " + shootPositions.Length);
                GameObject shoot = Instantiate(projectile);
                shoot.transform.position = shootPositions[i].position;
                shoot.transform.up = shootDirection.normalized;
                shoot.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * shootSpeed);
                shootTimer = 0;
            }
        }
    }

    void Moviment(){
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");
        transform.Translate(speed * Time.deltaTime * new Vector3(hMove, vMove).normalized);
        if (transform.position.x > screenLimit.x) transform.position = new Vector3(-screenLimit.x + .2f, transform.position.y);
        if (transform.position.x < -screenLimit.x) transform.position = new Vector3(screenLimit.x - .2f, transform.position.y);
        if (transform.position.y > screenLimit.y) transform.position = new Vector3(transform.position.x, -screenLimit.y + .2f);
        if (transform.position.y < -screenLimit.y) transform.position = new Vector3(transform.position.x, screenLimit.y - .2f);
    }

}
