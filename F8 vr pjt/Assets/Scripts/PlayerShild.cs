using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShild : MonoBehaviour
{
    public bool ShildGotHit;
    AudioSource ShildGotHitSound;
    BoxCollider collider;

    void Start()
    {
        ShildGotHitSound = GetComponent<AudioSource>();
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            collider.enabled = true;
        }
          if(Input.GetMouseButtonUp(1)){
            collider.enabled = false;
        }   
    }

    void OnTriggerEnter(Collider col){
        if(collider.enabled == true){
            if(col.tag == "DamageBox"){
                ShildGotHit = true;
                ShildGotHitSound.Play(0);
            }
        }
    }




}
