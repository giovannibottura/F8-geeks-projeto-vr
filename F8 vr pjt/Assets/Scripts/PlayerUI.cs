using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{

    public EndGame endGame;
    public Text EndGameTXT;

    public Text BBtext;
    public Text collectText;
    public Player player;
    public PlayerShild playerShild;
    float timeDefend;
    float timeAtack;
    public bool AD;
    public bool AT;
    public Slider AttackSlider;
    public Slider DefendSlider;

    // public Image FillDefend;

    void Start()
    {

        AttackSlider.maxValue = player.timeForAtack;
        AttackSlider.value = player.timeForAtack;
        DefendSlider.maxValue = player.timeForDefend;
        DefendSlider.value = player.timeForDefend;
        timeAtack = player.timeForAtack; 
        timeDefend = player.timeForDefend; 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.CanColect == true){
            collectText.enabled = true;
        }
        else if(player.CanColect == false){
            collectText.enabled = false;
        }

        
        if(player.CanColectBB && player.BBColected == true){
            BBtext.enabled = true;
        }     
        else if(player.BBColected == false){
            BBtext.enabled = false;
        }
        
        if(endGame.CanEnd == true){
            EndGameTXT.enabled = true;
        }
        else if(endGame.CanEnd == false){
            EndGameTXT.enabled = false;
        }

        if(playerShild.ShildGotHit == true){
            StartCoroutine(DefendTimer());
            playerShild.ShildGotHit = false;
        }
       
        if(AD == true){
            TimeContDownDefend();
            
        }
        if(timeDefend <=0){
            AD = false;
            timeDefend = player.timeForDefend;
            
        }
        
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(AttackTimer());
        }
        if(AT == true){
            TimeContDownAtack();
        }
        if(timeAtack <= 0){
            AT = false;
           
            timeAtack = player.timeForAtack;
        }
        AttackSlider.value = timeAtack;
        DefendSlider.value = timeDefend;       

    }
  
  
    void TimeContDownAtack(){
        timeAtack -= Time.deltaTime;
    }

    void TimeContDownDefend(){
        timeDefend -= Time.deltaTime;
    }
        
        
        
        
    IEnumerator AttackTimer(){
        yield return new WaitForSeconds(0.2f);
        //SliderApearSword();
        AT = true;
    }  
    IEnumerator DefendTimer(){
        yield return new WaitForSeconds(0.1f);
        AD = true;
        //SliderApearShild();
    }    
    // void SliderApearSword()
}
