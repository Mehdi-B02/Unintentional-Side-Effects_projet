using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D colid;
    
    [SerializeField] LayerMask ground;

    float speed = 10f;
    float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colid = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    void Move()
    {
        rb.velocity = new Vector2(speed * direction,rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(colid.bounds.center,colid.bounds.size,0f,Vector2.down,0.1f,ground);
    }
}
