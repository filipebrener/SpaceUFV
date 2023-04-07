using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour{

    public float speed = 1;

    public Vector2 screenLimit;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Moviment();
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
