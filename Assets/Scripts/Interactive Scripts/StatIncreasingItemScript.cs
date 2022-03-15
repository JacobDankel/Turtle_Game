using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatIncreasingItemScript : Item
{
    private GameObject player;

    public int healthIncrease = 0, damageIncrease = 0, speedIncrease = 0, jumpIncrease = 0;

    // Start is called before the first frame update
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
            //player.GetComponent<PlayerMovement>().
        }
        if (speedIncrease > 0)
        {
            player.GetComponent<PlayerMovement>().speed += speedIncrease;
        }
        if (jumpIncrease > 0)
        {
            // not implemented correctly right now
            //player.GetComponent<PlayerMovement>().jumpForce += jumpIncrease;
        }
    }
}
