using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{   

    public bool canEndHero;
    public GameObject BB;
    Animator anim;
    public Child child;
    public bool BBColected;
    public FarmerEnemy farmerEnemy;
    Transform player;
    
    void Start()
    {
        BBColected = false;
        anim = GetComponent<Animator>();
        BB.SetActive(true);
        farmerEnemy.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("OVRPlayerController").transform;
       // if(farmerEnemy.playerInSightRange){
           //  transform.LookAt(player);
        //}
       
        if(BBColected == true){
            BB.SetActive(true);
            anim.GetComponent<Animator>().Play("ChildColected");
            canEndHero = true;
            BBColected = false;
        }

        if(child.BabyDead == true){
             anim.GetComponent<Animator>().Play("babydead22");     
            child.BabyDead = false;     
            // StartCoroutine(Wait());
        }

        
    }

    

        IEnumerator Wait()
    {
        yield return new WaitForSeconds(9);
         farmerEnemy.enabled = true;  
    }



}
