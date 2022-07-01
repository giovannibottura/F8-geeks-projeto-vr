using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour
{   
    public PlayerUI PlayerUi;
    public Player player;
    public HealthBarScrip Pontos;
    public ParticleSystem part;
    bool CanColect;
    void Start()
    {
        CanColect = false;
    }

    // Update is called once per frame
    void Update()
    {

    
        if(CanColect == true){
            if(Input.GetKeyDown(KeyCode.C)){
                StartCoroutine(timer());
                this.GetComponent<Animator>().Play("ZOOON"); 
                Pontos.points = Pontos.points + 10; 
//                PlayerUi.collectText.enabled = false;
                CanColect = false;
                player.CanColect = false;
                Instantiate(part, part.transform.position, transform.rotation);
            }
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player" ){
            CanColect = true;
        
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Player" ){
            CanColect = false;
        }   
    }
            
    IEnumerator timer(){
       // PlayerUi.collectText.enabled = false;
        CanColect = false;
        player.CanColect = false;        

        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        //PlayerUi.collectText.enabled = false;

    }  
}
