using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerScript : MonoBehaviour
{
    public BoxCollider2D col;
    public GameObject wall;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wall.SetActive(true);
        }
    }
}
