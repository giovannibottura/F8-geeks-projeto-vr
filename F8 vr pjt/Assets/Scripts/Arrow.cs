using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    AudioSource ArrowSound;
    
    public BoxCollider collider;

    void Start()
    {
        ArrowSound = GetComponent<AudioSource>();
        StartCoroutine(DestroyItSelf());
        ArrowSound.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnTriggerEnter(Collider col){
    //     if(col.tag == "Player"){
    //         collider.enabled = false;
    //     }   

  //  }
     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.layer == 7){
            ArrowSound.Stop();
           // collider.enabled = false;
        }     
    }

 IEnumerator DestroyItSelf()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

}
