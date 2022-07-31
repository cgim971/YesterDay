using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnter : MonoBehaviour
{
    public GameObject shop;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OpenShop();
        }
    }
    private void OpenShop()
    {
        shop.gameObject.SetActive(true);
    }
}
