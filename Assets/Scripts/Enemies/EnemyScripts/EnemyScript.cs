using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : EnemyClass
{

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tran = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        takeDamage(1);
    }

    private void FixedUpdate()
    {
        moveRB();
    }
}
