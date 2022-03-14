using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite openSprite;
    [SerializeField]
    private GameObject exitPoint;

    private GameObject player;


    private bool isOpen = false;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().isInteracting() && (collision.GetComponent<PlayerMovement>().inventory.exists("Key") && !isOpen || isOpen))
        {
            collision.GetComponent<PlayerMovement>().inventory.inventoryList();
            //Debug.Log(collision.GetComponent<PlayerMovement>().inventory.exists("Key") + " Is opening");
            openDoor();
            collision.GetComponent<PlayerMovement>().inventory.removeItem("Key");


            exitPoint.GetComponent<DoorScript>().openDoor();
            collision.transform.position = exitPoint.transform.position;
        }
    }
    */

    public override void Interact()
    {
        if ((!isOpen && player.GetComponent<PlayerMovement>().inventory.exists("Key")) || isOpen)
        {
            openDoor();
            player.GetComponent<PlayerMovement>().inventory.removeItem("Key");

            exitPoint.GetComponent<DoorScript>().openDoor();
            player.transform.position = exitPoint.transform.position;
        }
    }


    public void openDoor()
    {
        spriteRenderer.sprite = openSprite;
        isOpen = true;
    }
}
