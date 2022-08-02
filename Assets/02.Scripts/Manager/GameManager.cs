using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UIManager uiManager { get; set; }

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

}
