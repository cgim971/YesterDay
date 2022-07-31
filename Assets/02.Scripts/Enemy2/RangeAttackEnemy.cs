using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackEnemy : MonoBehaviour
{
    public float distance;
    public Transform other;
    SpriteRenderer spriteRenderer;
    public LayerMask isLayer;
    public float atkDistance;
    public float speed;
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float currentTime;
    public Vector3 startPosition;
    public float maxTime;
    public float curTime;
    Animator anim;
    private void Start()
    {
        startPosition = transform.position;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Vector3.Distance(other.position, transform.position) <= 6f)
        {
            anim.SetBool("isAttack", true);
        }
        else if (Vector3.Distance(other.position, transform.position) >= 6f)
        {
            anim.SetBool("isAttack", false);
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D right = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if(right.collider != null)
        {
            curTime = 0;
            if (Vector2.Distance(transform.position, right.collider.transform.position) < atkDistance)
            {
                if(currentTime <= 0)
                {
                    GameObject bulletcopy = Instantiate(bullet, pos.position, transform.rotation);
                    currentTime = cooltime;
                }
                
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, right.collider.transform.position, Time.deltaTime * speed);
            }
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime += Time.deltaTime;
            if(currentTime >= maxTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * speed);
            }
        }
       

    }
}
