using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    public Rigidbody2D rb2d;
    public float destroyTime = 1.5f, damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * speed;
    }

    private void LateUpdate()
    {
        Destroy(gameObject, destroyTime);           //Destroys Projectile Gameobject after destroyTime has elapsed on creation.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.SendMessage("takeDamage", damage);
        }
    }
}
