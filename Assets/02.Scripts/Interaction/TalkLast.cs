using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkLast : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Exitclick()
    {
        this.gameObject.SetActive(false);
        
    }
}
