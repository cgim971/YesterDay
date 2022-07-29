using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall02 : MonoBehaviour
{
    RangeAttackEnemy range_scripts;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent.gameObject.transform.position = new Vector3(6, -3, 0);


        }



    }
    
}
