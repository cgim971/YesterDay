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
    Animator anim;
    public Transform other;
    
    
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ray = new Ray2D();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    void Start()
    {
        
        StartCoroutine("monsterAI");
    }


    void Update()
    {
        if (Vector3.Distance(other.position, transform.position) <= 2.3f)
        {
            anim.SetBool("isAttack", true);
        }
        else if (Vector3.Distance(other.position, transform.position) >= 2.3f)
        {
            anim.SetBool("isAttack", false);
        }


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
        if (moveDir != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

    }


    IEnumerator monsterAI()
    {
        
        moveDir = Random.Range(-1, 2);   // -1<= ranNum <2
        int rand = Random.Range(2, 5);
        yield return new WaitForSeconds(rand);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // find player
        if (collision.gameObject.tag == "Player")
        {

            stopMove();
            Vector3 playerPos = collision.transform.position;
            if (playerPos.x > transform.position.x)
            {
                moveDir = 3;     // speed up
                



            }
            else if (playerPos.x < transform.position.x)
            {
                moveDir = -3;
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            startMove();
    }

    



}

