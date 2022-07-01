using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScrip : MonoBehaviour
{
    public int points = 0;
    public Slider slider;
    public Text PointsTxt;
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
        PointsTxt.text = points.ToString();
    }
}
