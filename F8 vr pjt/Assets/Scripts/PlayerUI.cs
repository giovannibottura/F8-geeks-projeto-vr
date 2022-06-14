using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{

    public Player player;
    public PlayerShild playerShild;
    public float timeDefend;
    public float timeAtack;
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
        
        
        // if(FillAtack != null){
        //     if(FillAtack.GetComponent<Image>().color.a > 0){
        //         var color = FillAtack.GetComponent<Image>().color;
        //         var color1 = ImageSwo.GetComponent<RawImage>().color;
            
        //         color.a -= 1f;
        //         color1.a -= 1f;
        //         ImageSwo.GetComponent<RawImage>().color = color1;
        //         FillAtack.GetComponent<Image>().color = color;
        //     }
        // }
        // if(FillDefend != null){
        //     if(FillDefend.GetComponent<Image>().color.a > 0){
        //         var color3 = FillDefend.GetComponent<Image>().color;
        //         var color4 = ImageShild.GetComponent<RawImage>().color;
            
        //         color3.a -= 10f;
        //         color4.a -= 10f;
        //         ImageShild.GetComponent<RawImage>().color = color4;
        //         FillDefend.GetComponent<Image>().color = color3;
        //     }
        // }
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
    IEnumerator waitDefend() {
        yield return new WaitForSeconds(0.2f);


    }  
    // void SliderApearSword(){
    //     var color = FillAtack.GetComponent<Image>().color;
    //     var color1 = ImageSwo.GetComponent<RawImage>().color;
    //     color.a = 255f;
    //     color1.a = 255f;
    //     FillAtack.GetComponent<Image>().color = color;
    //     ImageSwo.GetComponent<RawImage>().color = color1;
    // } 
    // void SliderApearShild(){
    //     var color3 = FillDefend.GetComponent<Image>().color;
    //     var color4 = ImageShild.GetComponent<RawImage>().color;
    //     color3.a = 1600f;
    //     color4.a = 1600f;
    //     FillDefend.GetComponent<Image>().color = color3;
    //     ImageShild.GetComponent<RawImage>().color = color4;
    // } 
}
