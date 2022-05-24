using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBarScrip HealthBar;
    public int health;
    
    public bool AninDefend;
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
        if(Input.GetMouseButtonDown(0)){
            PlayerAnim.GetComponent<Animator>().Play("PlayerAttack");
        }
        if(Input.GetMouseButtonDown(1)){
            PlayerAnim.GetComponent<Animator>().Play("PlayerAttackDefend");
            AninDefend = true;
        }
        if(Input.GetMouseButtonUp(1)){
            PlayerAnim.GetComponent<Animator>().Play("PlayerAttackDefend2");
            AninDefend = false;
        }
    }

    void OnTriggerEnter(Collider other){
       if(other.tag == "Damage enemy"){
           health = health -1 ;
           HealthBar.sethealth(health);
       }
    }
    
    void die(){
        if(health == 0){
            Destroy(this.gameObject);
        }
    }
    
   

}
