using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D colid;    

    [SerializeField] LayerMask ground;

    [SerializeField] GameObject prefab;
    [SerializeField] GameObject spawnPoint;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    float horizontal;
    float vertical;

    bool lookRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colid = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Jump(IsGrounded());
        Shoot();
        Flip();
    }

    void FixedUpdate() 
    {
        Move();
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Jump(bool isGround)
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(colid.bounds.center,colid.bounds.size,0f,Vector2.down,0.1f,ground);
    }

    void Flip()
    {
        if(horizontal < 0 && lookRight)
        {
            transform.Rotate(0,180,0); 
            lookRight = !lookRight;
        }        
        else if(horizontal > 0 && !lookRight)
        {
            transform.Rotate(0,180,0);
            lookRight = !lookRight;
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(prefab,spawnPoint.transform.position,spawnPoint.transform.rotation);
        }        
    }
}
