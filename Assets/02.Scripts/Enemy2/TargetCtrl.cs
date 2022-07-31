using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCtrl : MonoBehaviour
{
    /*Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // find player
        if (collision.gameObject.tag == "Player")
        {
            
            transform.parent.GetComponent<EnemMove2>().stopMove();
            Vector3 playerPos = collision.transform.position;
            if (playerPos.x > transform.position.x)
            {
                transform.parent.GetComponent<EnemMove2>().moveDir = 3;     // speed up
                


            }
            else if (playerPos.x < transform.position.x)
            {
                transform.parent.GetComponent<EnemMove2>().moveDir = -3;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            transform.parent.GetComponent<EnemMove2>().startMove();
    }*/
}

