using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private int speedAnimatorId = Animator.StringToHash("Speed");
    private int groundAnimatorId = Animator.StringToHash("Ground");
    private int verticalSpeedAnimatorId = Animator.StringToHash("vSpeed");
    private int crouchAnimatorId = Animator.StringToHash("Crouch");
    private float movement = 0f;
    private float movementSpeed = 8f;
    private bool jump = false;
    private float jumpForce = 500f;
    private bool highJump = false;
    private float highJumpForce = 800f;
    private bool isGrounded = true;
    private bool crouch = false;
    private bool facingRight = true;
    private bool isDead = false;

    public Rigidbody2D Rigidbody => rigidbody2d;

    void Update()
    {
        GetInput();
        UpdateAnimator();
    }

    private void FixedUpdate() 
    {
        UpdateMovement();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void GetInput() 
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        if (!jump && isGrounded)
        {
            jump = Input.GetButtonDown("Jump");
        }

        if (!jump && !highJump && isGrounded)
        {
            highJump = Input.GetButtonDown("HighJump");
        }

        float vertical = Input.GetAxis("Vertical");
        crouch = vertical < 0f;
    }

    private void UpdateMovement()
    {
        rigidbody2d.velocity = new Vector2(movement, rigidbody2d.velocity.y);

        if (jump)
        {
            jump = false;
            rigidbody2d.AddForce(Vector2.up * jumpForce);
        }
        else if (highJump)
        {
            highJump = false;
            rigidbody2d.AddForce(Vector2.up * highJumpForce);
        }

        if (movement > 0f && !facingRight)
        {
            FlipSprite();
        }
        else if (movement < 0f && facingRight)
        {
            FlipSprite();
        }
    }

    private void UpdateAnimator()
    {
        float absMovement = Mathf.Abs(movement);

        animator.SetFloat(speedAnimatorId, absMovement);
        animator.SetBool(groundAnimatorId, isGrounded);
        animator.SetFloat(verticalSpeedAnimatorId, rigidbody2d.velocity.y);
        animator.SetBool(crouchAnimatorId, crouch);
    }

    private void FlipSprite()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }

    public void Kill()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        movement = 0f;
        jump = false;
        highJump = false;
        Destroy(gameObject);

        GameController.Instance.HandleGameOver();
    }
}
