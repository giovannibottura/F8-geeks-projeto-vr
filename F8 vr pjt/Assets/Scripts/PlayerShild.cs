using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShild : MonoBehaviour
{
    public bool ShildGotHit;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Damage enemy"){
            ShildGotHit = true;
        }
    }




}
