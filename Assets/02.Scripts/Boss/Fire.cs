using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : MonoBehaviour
{
    public float speed = 10f;

    
    private void Start()
    {
        
    }
    private void Update()
    {
        
            Vector3 dir = Vector3.left;
            transform.position += dir * speed * Time.deltaTime;
        

       

        

    }

}
