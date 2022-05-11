using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAttackScript : MonoBehaviour
{
    private float damage;
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
        damage = gameObject.GetComponentInParent<MeleeEnemy>().damage;
        //Debug.Log("Hit Something");
        if (collision.tag == "Player")
        {
            //Debug.Log("Hit Player");
            collision.SendMessage("takeDamage", damage);
        }
    }
}
