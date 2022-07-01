using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{   
    public Farmer farmer;
    public HealthBarScrip pontosSc;
    public Child child;


    public bool CanEnd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanEnd == true){
            if(Input.GetKeyDown(KeyCode.C)){
                if(farmer.canEndHero == true){
                    SceneManager.LoadScene(5);
                }
            //    if(farmer.BBColected == true){
            //         SceneManager.LoadScene(4);
            //     }
                else if(pontosSc.points >= 20){
                    SceneManager.LoadScene(2);
                }
                else if (child.BabyDead == true){
                    SceneManager.LoadScene(3);
                }   
                else if(farmer.canEndHero == true && pontosSc.points >= 20){
                    SceneManager.LoadScene(5);
                }
                else{
                    SceneManager.LoadScene(4);
                }
                // ReloadSene   
            }
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player" ){
            CanEnd = true;
            
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Player" ){
            CanEnd = false;
        }   
    }

}

