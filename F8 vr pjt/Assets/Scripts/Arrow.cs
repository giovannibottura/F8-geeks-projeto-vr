using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public BoxCollider collider;

    void Start()
    {
        StartCoroutine(DestroyItSelf());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            collider.enabled = false;
        }
    }

 IEnumerator DestroyItSelf()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

}
