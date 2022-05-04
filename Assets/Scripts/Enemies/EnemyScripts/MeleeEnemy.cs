using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyClass
{
    //[SerializeField]
    //private Animator anim;
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
        capCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        attack();

        if (isMoving == true)
        {
            anim.SetBool("Is Moving", true);
        }
        else anim.SetBool("Is Moving", false);
    }

    private void FixedUpdate()
    {
        if (isCurrentlyAttacking)
        {
            rb2d.velocity = Vector2.zero;
        }
        else moveRB();
        //rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
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
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(attackDelayTime);
            isCurrentlyAttacking = false;
        }
    }

    IEnumerator attackDelayLeft()
    {
        if (!isCurrentlyAttacking)
        {
            flip();
            isCurrentlyAttacking = true;
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(attackDelayTime);
            isCurrentlyAttacking = false;
        }
    }

    void patrolMelee()
    {
        if (atCorner() || seesWall() || seesOtherEnemy())
        {
            flipMelee();
        }
    }

    void flipMelee()
    {
        direction = -direction;
        /*
        if (direction == 1)
        {
            tran.Rotate(0f, 180f, 0f);
        }
        if (direction == -1)
        {
            tran.Rotate(0f, 180f, 0f);
        }
        */
        tran.Rotate(0f, 180f, 0f);
        Debug.Log("melee flipped");
    }
}

