using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyClass
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private CapsuleCollider2D rangeColliderRight, rangeColliderLeft;
    [SerializeField]
    private float attackDelayTime = 1f; //In seconds

    private bool isPlayerInRangeRight, isPlayerInRangeLeft, isCurrentlyAttacking;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tran = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        takeDamage(1);
        attack();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
    }

    private void attack()
    {
        if (rangeColliderRight.IsTouchingLayers(playerLayer))
        {
            isPlayerInRangeRight = true;
        }
        else isPlayerInRangeRight = false;
        if (rangeColliderLeft.IsTouchingLayers(playerLayer))
        {
            isPlayerInRangeLeft = true;
        }
        else isPlayerInRangeLeft = false;
        if (isPlayerInRangeRight)
        {
            StartCoroutine(attackDelayRight());
        }
        else if (isPlayerInRangeLeft)
        {
            StartCoroutine(attackDelayLeft());
        }
    }

    IEnumerator attackDelayRight()
    {
        if (!isCurrentlyAttacking)
        {
            isCurrentlyAttacking = true;
            anim.SetTrigger("AttackRight");
            yield return new WaitForSeconds(attackDelayTime);
            isCurrentlyAttacking = false;
        }
    }

    IEnumerator attackDelayLeft()
    {
        if (!isCurrentlyAttacking)
        {
            isCurrentlyAttacking = true;
            anim.SetTrigger("AttackLeft");
            yield return new WaitForSeconds(attackDelayTime);
            isCurrentlyAttacking = false;
        }
    }
}

