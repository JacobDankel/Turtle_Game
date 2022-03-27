using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawScript : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        damage = gameObject.GetComponentInParent<PlayerMovement>().weaponDamage;
        //Debug.Log("Hit Something");
        if (collision.tag == "Enemy")
        {
            //Debug.Log("Hit Enemy");
            collision.SendMessage("takeDamage", damage);
        }
    }
}
