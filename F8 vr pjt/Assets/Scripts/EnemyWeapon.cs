using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public bool AninDefend;
    void Update()
    {
        if(Input.GetMouseButtonUp(1)){
            AninDefend = false;
        } 
    }
 
    void OnTriggerEnter(Collider col){
        if(col.tag == "A1"){
            print ("asdfnlknaklsf");
            AninDefend = true;
        }
    }
   
}
