using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float speed, corrSpeed = 10;
    private float jumpForce = 25, jumpForce2;
    private int onGround = 0;
    private bool doubleJumpIsReady = false;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPos = transform.position;
        speed = corrSpeed;
        jumpForce2 = jumpForce * 1.2f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (onGround > 0 || doubleJumpIsReady))
        {
            if(onGround > 0)
            {
                Jump();
            }
            else if (doubleJumpIsReady)
            {
                Jump();
                doubleJumpIsReady = false;
            }
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = corrSpeed * 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = corrSpeed;
        }
        if (transform.position.y < -13)
        {
            Die();
        }
    }
    void FixedUpdate()
    {
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Ground")
        {
            onGround++;
            doubleJumpIsReady = true;
            anim.SetInteger("onGround", onGround);
        }
        else if (tag == "Enemy")
        {
            Die();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Ground")
        {
            onGround--;
            anim.SetInteger("onGround", onGround);
        }
    }
    public void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        transform.localScale = new Vector3(Math.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
    }
    public void Jump()
    {
        AudioManager.Play("sound_0");
        if (onGround > 0)
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
        else
        {
            rb.velocity = new Vector2(0, jumpForce2);
        }
    }
    private void Die()
    {
        transform.position = startPos;
    }
}
