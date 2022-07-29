using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;

    private void Start()
    {
        Invoke("DestroyBullet", 2);
    }
    private void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (raycast.collider != null)
        {
            if (raycast.collider.tag == "Player")
            {
                Debug.Log("ÃÑ¾Ë ¸ÂÀ½");
            }
            DestroyBullet();
        }
        //transform.Translate(transform.right * -1f * speed * Time.deltaTime);
        if(transform.rotation.y == 0)
        {
            transform.Translate(transform.right * -1 *  speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
