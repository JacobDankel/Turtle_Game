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
    protected LayerMask groundLayer, damageLayer, playerLayer;
    [SerializeField]
    protected float speed = 2f, direction = 1f, health = 2f, viewRange = 10f;
    [SerializeField]
    protected float extraRaycastLength = 6f;// This is the extra length from the rigidbody that the raycast extends to detect the ground. It should be just below the rb in most cases.

    public float damage = 1f;

    // Loot!
    [SerializeField]
    private GameObject lootDrop;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tran = GetComponent<Transform>();
        capCollider = GetComponent<CapsuleCollider2D>();
        takeDamage(10);
    }
    
    protected void moveRB()
    {
        rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);
    }


    protected void takeDamage(float _damage)
    {
        if (capCollider.IsTouchingLayers(damageLayer))
        {
            health -= _damage;
        }
        if (health == 0)
        {
            if (lootDrop != null)
            {
                Instantiate(lootDrop, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    protected void patrol()
    {
        if (atCorner() || seesWall())
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
        //Debug.DrawRay(rightExtent, (capCollider.bounds.extents*Vector2.down), Color.green);

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
}
