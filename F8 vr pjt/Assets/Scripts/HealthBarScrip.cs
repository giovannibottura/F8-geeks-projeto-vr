using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScrip : MonoBehaviour
{

    public Slider slider;

    public void setmaxhealth(int EnemyHealth){
        slider.maxValue = EnemyHealth;
        slider.value = EnemyHealth;
    }
    public void sethealth(int EnemyHealth){
        slider.value = EnemyHealth;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
