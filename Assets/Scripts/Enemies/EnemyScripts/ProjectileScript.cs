using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
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
        rb2d.velocity = transform.right * speed;
    }

    private void LateUpdate()
    {
        Destroy(gameObject, destroyTime);           //Destroys Projectile Gameobject after destroyTime has elapsed on creation.
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
            Debug.Log(collision.name);
            Destroy(gameObject);
        }
    }
}
