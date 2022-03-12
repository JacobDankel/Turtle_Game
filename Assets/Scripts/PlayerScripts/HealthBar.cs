using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Slider slider;
    //public GameObject player;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }

    /*
    private void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //SetMaxHealth(player.GetComponent<PlayerMovement>().maxHealth);
    }

    private void Update()
    {
        //SetHealth(player.GetComponent<PlayerMovement>().currentHealth);
    }
    */
}
