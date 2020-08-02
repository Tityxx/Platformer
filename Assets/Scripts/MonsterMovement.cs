using UnityEngine;
using System;

public class MonsterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed = 5;
    public float distanceWalk = 5;
    private float startPosX;
    private bool isRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPosX = transform.position.x;
    }

    void Update()
    {
        if(transform.position.x > (startPosX + distanceWalk))
        {
            isRight = false;
        }
        else if(transform.position.x < (startPosX - distanceWalk))
        {
            isRight = true;
        }
    }

    private void FixedUpdate()
    {
       anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
       if (isRight)
       {
            MoveRight();
       }
       else
       {
            MoveLeft();
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
}
