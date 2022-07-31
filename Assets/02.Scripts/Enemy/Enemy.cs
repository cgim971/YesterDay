using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float hp = 10;

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)    
        {
            // death
        }
    }


}
