using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSlider : MonoBehaviour
{
    private GameObject Hpbar;

    private void Start()
    {
        Hpbar = GameObject.Find("Canvas/Slider");
    }
    private void Update()
    {
        Hpbar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
    }
}
