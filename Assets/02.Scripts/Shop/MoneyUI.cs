using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text myMoney;
    public Customer Money;
    // Start is called before the first frame update
    void Start()
    {
        myMoney = GameObject.Find("Money").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myMoney.text = "º¸À¯°ñµå " + Money.Money;
    }
}
