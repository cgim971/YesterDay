using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Assets/ScriptableObject/Item")]
public class ItemData : ScriptableObject
{
    public string _itemName;
    public Sprite _itemSprite;

    public bool _isGet;
    public int _itemCost;
    public int _itemTier;

    [Header("Increase Value")]
    public float _hp;
    public float _atk;
    public float _def;
    public float _spd;
    public float _blood;

    [Header("Item Type")]
    public ItemType _itemType;
}

public enum ItemType
{
    NONE,
    WEAPON,
    HELMET,
    ARMOR,
    PANTS,
    BOOTS,
    ACCESSORY,
}
