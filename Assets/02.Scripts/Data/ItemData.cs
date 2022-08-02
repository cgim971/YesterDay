using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Assets/ScriptableObject/Item")]
public class ItemData : ScriptableObject
{
    public string _itemName;
    public Sprite _itemSprite;


    public bool _isGet;
    public int _slotIndex;

    public int _itemCost;
    public int _itemTier;

    [Header("Increase Value")]
    public List<ItemEffect> _itemEffectList;

    [Header("Item Type")]
    public ItemType _itemType;
}

[System.Serializable]
public class ItemEffect
{
    public ItemEffectType _itemEffectType;
    public float value;
}

public enum ItemEffectType
{
    NONE,
    HP,
    ATK,
    DEF,
    SPD,
    BLOOD
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
