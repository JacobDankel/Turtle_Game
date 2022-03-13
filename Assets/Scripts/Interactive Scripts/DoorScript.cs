using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite openSprite;

    private bool isOpen = false;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().isInteracting() && collision.GetComponent<PlayerMovement>().inventory.exists("Key") && !isOpen)
        {
            collision.GetComponent<PlayerMovement>().inventory.inventoryList();
            Debug.Log(collision.GetComponent<PlayerMovement>().inventory.exists("Key") + " Is opening");
            spriteRenderer.sprite = openSprite;
            collision.GetComponent<PlayerMovement>().inventory.removeItem("Key");
            isOpen = true;
        }
    }
}
