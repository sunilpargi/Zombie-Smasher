using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int healthValue = 100;
    public Slider health_Slider;

    private GameObject UI_Holder;

    void Start()
    {
        health_Slider.value = healthValue;
        UI_Holder = GameObject.Find("UI Holder");
    }

    // Update is called once per frame
   public void ApplyDamage(int damageAmount)
    {
        healthValue -= damageAmount;

        if(healthValue < 0)
        {
            healthValue = 0;
        }
        health_Slider.value = healthValue;

        if(healthValue == 0)
        {
            UI_Holder.SetActive(false);
            GamePlayController.instance.GameOver();
        }
    }
}
