using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingManager : MonoBehaviour
{
    float minTime = 2;
    float maxTime = 6;
    float currentTime;
    public float createTime = 1f;
    
    public GameObject enemyFactory;
    private void Start()
    {

        createTime = Random.Range(minTime, maxTime);
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime > createTime)
        {
            GameObject FallOb = Instantiate(enemyFactory);
            FallOb.transform.position = transform.position;
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
