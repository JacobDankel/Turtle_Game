using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform tran;
    [SerializeField]
    private Rigidbody2D controller;
    [SerializeField]
    private CapsuleCollider2D capCollider;
    [SerializeField]
    private Animator anim;

    // HealthBar
    //[SerializeField]
    //private HealthBar healthBar;
    public Inventory inventory;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    public float speed = 4f, jumpForce = 10f, jumpCushion = 1f, jumpTime = .35f;

    private float jumpTimeCounter;
    private bool isJumping;

    private float horizontalMove;
    private float direction = 1;

    public float maxHealth = 3;

    public float currentHealth;

    // Start is called before the first frame update
    private void Start()
    {
        //Grab references for rigidbody and animator from body 
        tran = GetComponent<Transform>();
        controller = GetComponent<Rigidbody2D>();
        capCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();

        inventory = new Inventory();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
        {
            anim.SetBool("Moving", true);
        }
        else anim.SetBool("Moving", false);
        if (horizontalMove > 0)
        {
            direction = 1;
        }
        if (horizontalMove < 0)
        {
            direction = -1;
        }
        if (IsGrounded())
        {
            anim.SetBool("Grounded", true);
        }
        else anim.SetBool("Grounded", false);

        jumping();

        anim.SetFloat("Speed", horizontalMove);
        anim.SetFloat("Direction", direction);
    }

    private void FixedUpdate()
    {
        controller.velocity = new Vector2(horizontalMove * speed, controller.velocity.y);
    }

    public void pickUpItem(Item item)
    {
        inventory.addItem(item);
    }

    /*
     * Not necessarily a bug, but you can hold E and run over stuff and it will work. wasn't responsive with getButtonDown
     */
    public bool isInteracting()
    {
        if (Input.GetButton("Interact"))
        {
            return true;
        }
        else return false;
    }

    /*
    * Lets the player hold the button longer to jump higher. tap jump button = shorter jump.
    */
    private void jumping()
    {
        //initial jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            controller.velocity = Vector2.up * jumpForce * Time.deltaTime;
        }

        //if jump is held down, then player will continue to rise up to a certain point indicated by jumpTimeCounter which is initialized by jumpTime
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                controller.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    /*
    * Uses two raycasts on either side of the collider to test if it is on the ground. 
    * jumpCushion is to allow you to jump slightly earlier than sprite hits the ground.
    * groundLayer is a Layermask so that the Raycast only hits colliders in the "Ground" layer
    */
    bool IsGrounded()
    {
        Vector3 leftExtent = capCollider.bounds.center + Vector3.left * capCollider.bounds.extents.x; //left center point of capCollider
        Vector3 rightExtent = capCollider.bounds.center + Vector3.right * capCollider.bounds.extents.x; //right center point of capCollider

        RaycastHit2D lHit = Physics2D.Raycast(leftExtent, Vector2.down, jumpCushion, groundLayer);
        RaycastHit2D rHit = Physics2D.Raycast(rightExtent, Vector2.down, jumpCushion, groundLayer);
        if (lHit.collider != null || rHit.collider != null)
        {
            return true;
        }
        return false;
    }

    private void takeDamage(float _damage)
    {
        currentHealth -= _damage;

        //healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }
}
