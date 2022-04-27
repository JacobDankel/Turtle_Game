using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D rb2d;
    [SerializeField]
    protected Transform tran;
    [SerializeField]
    protected CapsuleCollider2D capCollider;
    [SerializeField]
    protected Animator anim;
    [SerializeField]
    protected LayerMask groundLayer, damageLayer, playerLayer, enemyLayer;
    [SerializeField]
    protected float speed = 2f, direction = 1f, health = 2f, viewRange = 10f;
    [SerializeField]
    protected float extraRaycastLength = 6f;// This is the extra length from the rigidbody that the raycast extends to detect the ground. It should be just below the rb in most cases.

    public bool isMoving;

    public float damage = 1f;

    public bool isInPain;

    // Loot!
    [SerializeField]
    protected GameObject lootDrop;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tran = GetComponent<Transform>();
        capCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }
    
    protected void moveRB()
    {
        rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
        isMoving = true;
    }


    protected void takeDamage(float _damage)
    {
        //Debug.Log("Taking fire!");
        health -= _damage;
        anim.SetTrigger("In Pain");
        if (health == 0)
        {
            if (lootDrop != null)
            {
                Instantiate(lootDrop, gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    protected void patrol()
    {
        if (atCorner() || seesWall() || seesOtherEnemy())
        {
            flip();
        }
    }

    /*
     * probably doesn't need two different raycasts if flip() is used but I don't want to remake it
    */
    protected bool atCorner()
    {
        Vector3 leftExtent = capCollider.bounds.center + (Vector3.left * capCollider.bounds.extents.x); //left center point of boxCollider
        Vector3 rightExtent = capCollider.bounds.center + (Vector3.right * capCollider.bounds.extents.x); //right center point of boxCollider
        
        RaycastHit2D lHit = Physics2D.Raycast(leftExtent, Vector2.down, capCollider.bounds.extents.y + extraRaycastLength, groundLayer);
        RaycastHit2D rHit = Physics2D.Raycast(rightExtent, Vector2.down, capCollider.bounds.extents.y + extraRaycastLength, groundLayer);
        Debug.DrawRay(rightExtent, (capCollider.bounds.extents*Vector2.down), Color.green);

        float left = -.01f;
        float right = .01f;
        
        if (!lHit.collider && direction <= left)
        {
            //Debug.Log("left corner");
            return true;
        }
        
        if (!rHit.collider && direction >= right)
        {
            //Debug.Log("right corner");
            return true;
        }
        else return false;
    }

    protected void flip()
    {
        direction = -direction;
        if (direction == 1)
        {
            tran.Rotate(0f, 180f, 0f);
        }
        if (direction == -1)
        {
            tran.Rotate(0f, 180f, 0f);
        }
    }

    protected bool seesPlayer()
    {
        RaycastHit2D visionLine = Physics2D.Raycast(capCollider.bounds.center, transform.right, viewRange, playerLayer);
        if (visionLine.collider)
        {
            //Debug.Log("I SEE YOU");
            return true;
        }
        else return false;
    }

    protected bool seesWall()
    {
        Vector3 bottomOfCollider = new Vector3(capCollider.bounds.center.x, capCollider.bounds.center.y - capCollider.bounds.extents.y);
        float range = capCollider.bounds.extents.x + .1f;

        RaycastHit2D wallVisionLine = Physics2D.Raycast(bottomOfCollider, transform.right, range, groundLayer);

        if (wallVisionLine.collider)
        {
            //Debug.Log("I see a wall");
            return true;
        }
        else return false;
    }
    
    protected bool seesOtherEnemy()
    {
        Vector3 centerRightOfCollider = new Vector3(capCollider.bounds.center.x + capCollider.bounds.extents.x +.01f, capCollider.bounds.center.y);
        Vector3 centerLeftOfCollider = new Vector3(capCollider.bounds.center.x - capCollider.bounds.extents.x - .01f, capCollider.bounds.center.y);
        float range = .1f;

        RaycastHit2D enemyVisionLineRight = Physics2D.Raycast(centerRightOfCollider, transform.right, range, enemyLayer);
        RaycastHit2D enemyVisionLineLeft = Physics2D.Raycast(centerLeftOfCollider, -transform.right, -range, enemyLayer);
        Debug.DrawRay(centerRightOfCollider, (range*Vector2.right), Color.green);
        Debug.DrawRay(centerLeftOfCollider, (range * Vector2.left), Color.green);

        if (enemyVisionLineRight.collider && (enemyVisionLineRight.collider != gameObject.GetComponent<CapsuleCollider2D>()))
        {
            //Debug.Log("I see another me");
            return true;
        }
        if (enemyVisionLineLeft.collider && (enemyVisionLineLeft.collider != gameObject.GetComponent<CapsuleCollider2D>()))
        {
            //Debug.Log("I see another me");
            return true;
        }

        else return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.SendMessage("takeDamage", damage);
        }
    }

    private void isInPainOn()
    {
        isInPain = true;
    }
    
    private void isInPainOff()
    {
        isInPain = false;
    }
}
