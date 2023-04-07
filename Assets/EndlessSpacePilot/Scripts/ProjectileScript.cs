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
}
