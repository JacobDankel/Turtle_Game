using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer, spriteRendererTop;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Sprite openSprite, openTopSprite;

    private bool isOpen = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //spriteRendererTop = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<PlayerMovement>().isInteracting() && collision.GetComponent<PlayerMovement>().inventory.exists("Key") && !isOpen)
        {
            collision.GetComponent<PlayerMovement>().inventory.inventoryList();
            Debug.Log(collision.GetComponent<PlayerMovement>().inventory.exists("Key"));
            anim.SetTrigger("Open");
            collision.GetComponent<PlayerMovement>().inventory.removeItem("Key");
            isOpen = true;
            //spriteRenderer.sprite = openSprite;
            //spriteRendererTop.sprite = openTopSprite;
        }
    }
}
