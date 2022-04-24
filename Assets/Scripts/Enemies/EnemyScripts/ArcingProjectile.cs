using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcingProjectile : ProjectileScript
{
    // Start is called before the first frame update
    void Start()
    {
        rb2d.GetComponent<Rigidbody2D>();
        speed = 7f;
        destroyTime = 5f;
        rb2d.velocity =  new Vector2(Random.Range(-1f, 1f), 1) * speed;
        //rb2d.velocity = new Vector2(Random.Range(.1f, 1f), Random.Range(.1f, 1f)) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
