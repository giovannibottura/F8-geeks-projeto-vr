using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VJHKVBHJL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke(nameof(OnTriggerEnter), 0.5f);
    }
    void OnTriggerEnter(Collider Other){
        if(Other.gameObject.tag == "V1"){
            print("asfnklasfnklfasmlçnjk");
        }
    }
}
