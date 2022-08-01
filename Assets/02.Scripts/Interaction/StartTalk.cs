using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTalk : MonoBehaviour
{
    public GameObject tk;
    public GameObject Fvisible;
    bool isTalk = false;
    private void Start()
    {
        Fvisible.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Fvisible.SetActive(true);
            
            isTalk = true;
        }
    }
    private void Update()
    {
        if (isTalk == true)
        {
            OpenShop();
        }
    }
    private void OpenShop()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            Fvisible.SetActive(false);
            tk.SetActive(true);
            
        }

    }

}
