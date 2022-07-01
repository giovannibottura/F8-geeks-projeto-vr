using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    AudioSource AtackSound;
    public BoxCollider collider;
    void Start()
    {
        collider.enabled = false;
        AtackSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            collider.enabled = true;
            StartCoroutine(AttackTimer());
        }

    }


    void OnTriggerEnter(Collider col){
        if(col.tag == "Enemy"){
            collider.enabled = false;
            AtackSound.Play(0);
        }
    }


    IEnumerator AttackTimer(){
        yield return new WaitForSeconds(1);
        collider.enabled = false;
    }

}
