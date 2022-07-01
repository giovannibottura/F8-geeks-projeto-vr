using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public PlayerUI playerUi;
    public GameObject BB;
    public Player player;
    bool CanColect;
    public GameObject particle;
    public bool BabyDead;
    void Start()
    {
        player.BBColected = false;
        BB.SetActive(false);
        BabyDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(CanColect == true){
            if(Input.GetKeyDown(KeyCode.C)){
                this.gameObject.SetActive(false);
                CanColect = false;
                player.CanColect = false;
                player.BBColected = true;
                BB.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player" ){
            CanColect = true;
        }
        if(other.tag == "PlayerWeapon"){
            Destroy(this.gameObject);
            Rigidbody rb = Instantiate(particle, transform.position, transform.rotation).GetComponent<Rigidbody>();
            BabyDead = true;
        }
    
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Player" ){
            playerUi.BBtext.enabled = false;
            CanColect = false;
        }   
    }
}
