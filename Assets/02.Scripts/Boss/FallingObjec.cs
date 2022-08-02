using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjec : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    private void Start()
    {
        
        int rand = Random.Range(0, 10);
        if (rand < 4)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }
    
    private void Update()
    {
        //Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
