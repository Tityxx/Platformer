using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject hitCollider;
    private Rigidbody2D rb;
    private Animator anim;
    private float speed, corrSpeed = 10;
    private float jumpForce = 25, jumpForce2;
    private int onGround = 0;
    private bool doubleJumpIsReady = false;
    private Vector3 startPos;
    private KeyCode keyLeft = KeyCode.LeftArrow, keyRight = KeyCode.RightArrow, keyJump = KeyCode.UpArrow,
        keyBoost = KeyCode.LeftShift, keyHit = KeyCode.Z;

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
        if (Input.GetKeyDown(keyJump) && (onGround > 0 || doubleJumpIsReady))
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
        if(Input.GetKey(keyBoost))
        {
            speed = corrSpeed * 1.5f;
        }
        if (Input.GetKeyUp(keyBoost))
        {
            speed = corrSpeed;
        }
        if (transform.position.y < -13)
        {
            Die();
        }
        if (Input.GetKeyDown(keyHit) && onGround > 0)
        {
            if(Mathf.Abs(rb.velocity.x) > 0)
            {
                Hit("Hit_and_Run");
            }
            else
            {
                Hit("Hit_and_Stay");
            }
        }
        if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("Hit_and_Run") || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit_and_Stay")))
        {
            hitCollider.SetActive(false);
        }
        else
        {
            hitCollider.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        
        if (Input.GetKey(keyLeft))
        {
            MoveLeft();
        }
        if (Input.GetKey(keyRight))
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
        //AudioManager.Play("sound_0");
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
    private void Hit(string str)
    {
        anim.Play(str);
        //hitCollider.SetActive(true);
    }
}
