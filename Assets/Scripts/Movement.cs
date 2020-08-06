using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject hitObject;
    private Animator hitAnimator;
    private CircleCollider2D hitCollider;
    private Rigidbody2D rb;
    private Animator anim;
    private float speed, corrSpeed = 10;
    private float jumpForce = 27, jumpForce2;
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
        hitAnimator = hitObject.GetComponentInChildren<Animator>();
        hitCollider = hitObject.GetComponent<CircleCollider2D>();
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
            //hitCollider.enabled = true;
            hitAnimator.Play("Hit");
        }
        //if (hitCollider.activeSelf == true)
        //{
        //    if (!hitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        //    {
        //        //hitCollider.SetActive(false);
        //    }
        //    else
        //    {
        //        hitCollider.SetActive(true);
        //    }
        //}
        if (!hitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            hitCollider.enabled = false;
        }
        else
        {
            hitCollider.enabled = true;
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
        else if (tag == "Enemy" || tag == "Monster")
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
    void OnTriggerEnter2D(Collider2D collider)
    {
        string tag = collider.gameObject.tag;
        if (tag == "Bonus")
        {
            Destroy(collider.gameObject);
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
            rb.velocity = new Vector2(0, jumpForce);
        }
    }
    private void Die()
    {
        transform.position = startPos;
    }
}
