using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAttack : MonoBehaviour
{
    public float damage = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("we in there");
        if (collision.tag == "Player")
        {
            //Debug.Log(gameObject + (" triggered"));
            collision.SendMessage("takeDamage", damage);
        }
    }

    /*
     * Should be triggered from animation once animation completes
     */
    private void done()
    {
        Destroy(gameObject);
    }
}
