using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcingProjectile : MonoBehaviour
{
    [SerializeField]
    protected float speed = 10f;
    [SerializeField]
    public Rigidbody2D rb2d;
    public float destroyTime = 1.5f, damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.GetComponent<Rigidbody2D>();
        speed = 7f;
        destroyTime = 5f;
        rb2d.velocity =  new Vector2(Random.Range(-1f, -.1f), 1) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().takeDamage(damage);
            //collision.SendMessage("takeDamage", damage);
        }
        if (collision.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
