using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public GameObject next;
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void Onclick()
    {
        this.gameObject.SetActive(false);
        next.gameObject.SetActive(true);
    }

}
