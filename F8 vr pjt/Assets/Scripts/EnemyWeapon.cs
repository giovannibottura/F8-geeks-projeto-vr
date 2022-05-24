using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public bool AninDefend;
    void Update()
    {
        //Invoke(nameof(OnTriggerEnter), 1f);
    }
 
    void OnTriggerEnter(Collider col){
        //if(col.gameObject.tag == "A1"){
            print ("asdfnlknaklsf");
            AninDefend = true;
       // }
    }
}
