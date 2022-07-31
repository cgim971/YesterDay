using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float Money;
    public int SwordCount = 0;
    public int HelmetCount = 0;
    public int ArmorCount = 0;
    public int LegCount = 0;
    public int BootsCount = 0;
    public int RingCount = 0;
    public int NeckCount = 0;

    public ItemData item;
    public void Buy(Celler celler, int swordCount) //�� ���� ����
    {
        
        if (swordCount > celler.SwordCount)
        {
            return;
        }
        int totalPrice = celler.SwordPrice * swordCount;

        if (Money >= totalPrice)
        {
            celler.SwordCount = celler.SwordCount - swordCount;
            celler.Money = celler.Money + totalPrice;
            Money = Money - totalPrice;
            SwordCount = SwordCount + swordCount;
            item.quantity++; // <- �� ������ quantity(����) 1 ����
        }
        
    }

    public void BuyH(Celler celler, int helmetCount) //��� ���� ����
    {
        if (helmetCount > celler.HelmetCount)
        {
            return;
        }
        int totalPrice = celler.HelmetPrice * helmetCount;

        if (Money >= totalPrice)
        {
            celler.HelmetCount = celler.SwordCount - helmetCount;
            celler.Money = celler.Money + totalPrice;
            Money = Money - totalPrice;
            HelmetCount = HelmetCount + helmetCount;
            item.quantity++; // <- ��� ������ quantity(����) 1 ����
        }
    }
    public void BuyA(Celler celler, int armorCount) //���� ���� ����
    {
        if (armorCount > celler.ArmorCount)
        {
            return;
        }
        int totalPrice = celler.ArmorPrice * armorCount;

        if (Money >= totalPrice)
        {
            celler.ArmorCount = celler.ArmorCount - armorCount;
            celler.Money = celler.Money + totalPrice;
            Money = Money - totalPrice;
            ArmorCount = ArmorCount + armorCount;
            item.quantity++; // <- ���� ������ quantity(����) 1 ����
        }
    }
    public void BuyL(Celler celler, int legCount) //�ٸ����� ���� ����
    {
        if (legCount > celler.LegCount)
        {
            return;
        }
        int totalPrice = celler.LegPrice * legCount;

        if (Money >= totalPrice)
        {
            celler.LegCount = celler.LegCount - legCount;
            celler.Money = celler.Money + totalPrice;
            Money = Money - totalPrice;
            LegCount = LegCount + legCount;
            item.quantity++; // <- �ٸ����� ������ quantity(����) 1 ����
        }
    }
    public void BuyB(Celler celler, int bootsCount) //���� ���� ����
    {
        if (bootsCount > celler.BootsCount)
        {
            return;
        }
        int totalPrice = celler.BootsPrice * bootsCount;

        if (Money >= totalPrice)
        {
            celler.BootsCount = celler.BootsCount - bootsCount;
            celler.Money = celler.Money + totalPrice;
            Money = Money - totalPrice;
            BootsCount = BootsCount + bootsCount;
            item.quantity++; // ���� ������ quantity(����) 1 ����
        }
    }
    public void BuyR(Celler celler, int ringCount) 
    {
        if (ringCount > celler.RingCount)
        {
            return;
        }
        int totalPrice = celler.RingPrice * ringCount;

        if (Money >= totalPrice)
        {
            celler.RingCount = celler.RingCount - ringCount;
            celler.Money = celler.Money + totalPrice;
            Money = Money - totalPrice;
            RingCount = RingCount + ringCount;
            item.quantity++; 
        }
    }
    public void BuyN(Celler celler, int neckCount)
    {
        if (neckCount > celler.NeckCount)
        {
            return;
        }
        int totalPrice = celler.NeckPrice * neckCount;

        if (Money >= totalPrice)
        {
            celler.NeckCount = celler.NeckCount - neckCount;
            celler.Money = celler.Money + totalPrice;
            Money = Money - totalPrice;
            NeckCount = NeckCount + neckCount;
            item.quantity++;
        }
    }
}
