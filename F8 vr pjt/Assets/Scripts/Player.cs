using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Farmer farmer;
    public bool BBColected;
    public Child BBscript;
    public bool CanColectBB;

    public AudioClip RunSound;
    public AudioClip WalkSound;
    AudioSource AtackSound;
    
    public PlayerUI playerUI;
    public GameObject DamageScream;
    public HealthBarScrip HealthBar;
    public int health;
    
    public float timeForAtack;
    public float timeForDefend;    
    
    bool Invencible;
    public int maxHealth;
    public Animator PlayerAnim;
    
    public bool CanColect;

    void Start()
    {  
        CanColectBB = false;
        AtackSound = GetComponent<AudioSource>();

        HealthBar.setmaxhealth(maxHealth);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(playerUI.AT == false){
            if(Input.GetMouseButtonDown(0)){
                PlayerAnim.GetComponent<Animator>().Play("PlayerAttack");   
                AtackSound.Play(0);
              
            }
        }    
       if(playerUI.AD == false){
            if(Input.GetMouseButtonDown(1)){
                PlayerAnim.GetComponent<Animator>().Play("PlayerAttackDefend");
                Invencible = true;
            }
        }    
        if(Input.GetMouseButtonUp(1)){
            PlayerAnim.GetComponent<Animator>().Play("PlayerAttackDefend2");
            Invencible = false;
        }
       
        if(DamageScream != null){
            if(DamageScream.GetComponent<Image>().color.a > 0){
                var color = DamageScream.GetComponent<Image>().color;
                color.a -= 0.01f;
                DamageScream.GetComponent<Image>().color = color;
            }
        }
        


        if(Input.GetKeyDown("w")){
            AtackSound.PlayOneShot(WalkSound);
        }
         if(Input.GetKeyUp("w")){
            AtackSound.Stop();
        }
        //  if(Input.GetKeyDown("w") && Input.GetKeyDown(KeyCode.LeftShift)){
        //     AtackSound.PlayOneShot(WalkSound);
        // }        
        // if(Input.GetKeyUp("w") && Input.GetKeyUp(KeyCode.LeftShift)){
        //    AtackSound.Stop();   
        // }  
        if(BBColected == true){
            if(CanColectBB == true){
                if(Input.GetKeyDown(KeyCode.C)){
                    BBscript.BB.SetActive(false);
                    farmer.BBColected = true;
                    BBColected = false;
                }        
            }
        }
        HealthBar.sethealth(health);
    }

    void OnTriggerEnter(Collider other){
       if(Invencible == false){
            if(other.tag == "DamageBox"){
                health = health -1 ;
                HealthBar.sethealth(health);
                gotHurt();
                print("mpjklfads");
            }
        }    
    
        if(other.tag == "Farmer"){
            CanColectBB = true;
        }

        if(other.tag == "Tresure"){
            CanColect = true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Tresure" ){
            CanColect = false;
        } 
        if(other.tag == "Farmer"){
            CanColectBB = false;
        }                
    }

    void gotHurt(){
        var color = DamageScream.GetComponent<Image>().color;
        color.a = 0.6f;
        
        DamageScream.GetComponent<Image>().color = color;
    }
    void die(){
        if(health <= 0){
            //Destroy(this.gameObject);
        }
    }
    

}
