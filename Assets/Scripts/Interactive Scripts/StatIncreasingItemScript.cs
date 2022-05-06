using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatIncreasingItemScript : Item
{
    private GameObject player;

    public float healthIncrease = 0, damageIncrease = 0, speedIncrease = 0, jumpIncrease = 0, healthRefill = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public override void effect()
    {
        if (healthIncrease > 0)
        {
            player.GetComponent<PlayerMovement>().maxHealth += healthIncrease;
            player.GetComponent<PlayerMovement>().currentHealth += healthIncrease;
        }
        if (damageIncrease > 0)
        {
            player.GetComponent<PlayerMovement>().weaponDamage += damageIncrease;
        }
        if (speedIncrease > 0)
        {
            player.GetComponent<PlayerMovement>().speed += speedIncrease;
        }
        if (jumpIncrease > 0)
        {
            player.GetComponent<PlayerMovement>().jumpTime += jumpIncrease;
        }
        if (healthRefill > 0)
        {
            if (player.GetComponent<PlayerMovement>().currentHealth < player.GetComponent<PlayerMovement>().maxHealth)
            {
                player.GetComponent<PlayerMovement>().currentHealth += healthRefill;
            }
        }
    }
}
