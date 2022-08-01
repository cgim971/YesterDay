using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    
    private void Start()
    {
        this.gameObject.SetActive(false);
        
    }
    public void Compete(Customer customer)
    {
        if (customer.Money < 0)
        {
            this.gameObject.SetActive(false);
            
        }
        else
        {
            this.gameObject.SetActive(true);
            Invoke("Done", 0.6f);
        }
        
        
        
    }
    public void Done()
    {
        
        this.gameObject.SetActive(false);
    }
}
