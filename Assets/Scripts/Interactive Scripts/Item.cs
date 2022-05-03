using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    //public int itemCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("here");
            SoundScript.play("Item Pickup");
            effect();
            collision.GetComponent<PlayerMovement>().pickUpItem(this);
            Destroy(gameObject);
        }
    }

    public abstract void effect();
}
