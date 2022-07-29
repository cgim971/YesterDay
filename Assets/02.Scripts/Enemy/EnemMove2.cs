using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemMove2 : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] float speed;
    Rigidbody2D rigid;
    RaycastHit2D rayHit;
    SpriteRenderer spriteRenderer;
    Ray2D ray;
    public int moveDir;    // Moving direction, Random
    BoxCollider2D boxcoll;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ray = new Ray2D();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
        StartCoroutine("monsterAI");
    }
    void Update()
    {
        if (rigid.velocity.x > 0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(moveDir, rigid.velocity.y);   // no jump monster
        float distance = 4.42f;
        if (moveDir > 0)
        {
            
            ray.direction = new Vector3(1, -1, 0);
            
            rayHit = Physics2D.Raycast(rigid.position, ray.direction, distance, ~3);
        }
        else
        {
            
            ray.direction = new Vector3(-1, -1, 0);
            rayHit = Physics2D.Raycast(rigid.position, ray.direction, distance, ~3);

        }
        if (!rayHit)
        {
            moveDir = -moveDir;
        }
        
    }
    
    
    IEnumerator monsterAI()
    {
        
        moveDir = Random.Range(-1, 2);   // -1<= ranNum <2
        int rand = Random.Range(2, 5);
        yield return new WaitForSeconds(5f);
        StartCoroutine("monsterAI");
    }

    public void startMove()
    {
        StartCoroutine("monsterAI");
    }

    public void stopMove()
    {
        StopCoroutine("monsterAI");
    }

}

