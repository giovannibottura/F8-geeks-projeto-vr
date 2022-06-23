using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerUI playerUI;

    public GameObject DamageScream;
    public HealthBarScrip HealthBar;
    public int health;
    
    public float timeForAtack;
    public float timeForDefend;    
    bool Invencible;
    public int maxHealth = 5;
    public Animator PlayerAnim;
  
    void Start()
    {  


       HealthBar.setmaxhealth(maxHealth);
       health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(playerUI.AT == false){
            if(Input.GetMouseButtonDown(0)){
                PlayerAnim.GetComponent<Animator>().Play("PlayerAttack");   
              
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
    }

    void OnTriggerEnter(Collider other){
        if(Invencible == false){
            if(other.tag == "Damage enemy"){
                health = health -1 ;
                HealthBar.sethealth(health);
                gotHurt();
            }
        }    
    }

    void gotHurt(){
        var color = DamageScream.GetComponent<Image>().color;
        color.a = 0.8f;
        DamageScream.GetComponent<Image>().color = color;
    }
    void die(){
        if(health <= 0){
            //Destroy(this.gameObject);
        }
    }
    

}
