using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    RaycastHit2D rayHit;
    Ray2D ray;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ray = new Ray2D();
        
    }


    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        FlipSprite();
    }


    void FixedUpdate()
    {
        float distance = 4.42f;
        if (speed > 0)
        {
            ray.direction = new Vector3(1, -1, 0);
            rayHit = Physics2D.Raycast(rb.position, ray.direction, distance, ~3);
        }
        else
        {
            ray.direction = new Vector3(-1, -1, 0);
            rayHit = Physics2D.Raycast(rb.position, ray.direction, distance, ~3);

        }
        if (!rayHit)
        {
            speed = -speed;
        }
    }
    void FlipSprite()
    {
        bool playerHasSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }


    }
}

