using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Celler CellerInShop;
    public Customer CustomerInShop;

    
    public void BuySword()
    {
        CustomerInShop.Buy(CellerInShop, 1);
    }
    public void BuyHelmet()
    {
        CustomerInShop.BuyH(CellerInShop, 1);
    }
    public void BuyArmor()
    {
        CustomerInShop.BuyA(CellerInShop, 1);
    }
    public void BuyLeg()
    {
        CustomerInShop.BuyL(CellerInShop, 1);
    }
    public void BuyBoots()
    {
        CustomerInShop.BuyB(CellerInShop, 1);
    }
    public void BuyRing()
    {
        CustomerInShop.BuyR(CellerInShop, 1);
    }
    public void BuyNeckless()
    {
        CustomerInShop.BuyN(CellerInShop, 1);
    }
}
