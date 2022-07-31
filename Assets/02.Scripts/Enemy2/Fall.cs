using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            
            transform.parent.GetComponent<EnemMove2>().startMove();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
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
}
