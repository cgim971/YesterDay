using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    ItemData _itemData;
    public ItemData ITEMDATA
    {
        get => _itemData;
        set
        {
            _itemData = value;
            RefreshSlot();
        }
    }
    [SerializeField] private int _slotIndex;
    public int SLOTINDEX
    {
        get => _slotIndex;
        set => _slotIndex = value;
    }

    [SerializeField] private Image _itemImage;
    
    private void Start()
    {
        RefreshSlot();
    }

    public void RefreshSlot()
    {
        if(_itemData == null)
        {
            _itemImage.color = new Color(1, 1, 1, 0);
            return;
        }
        _itemImage.color = new Color(1, 1, 1, 1);

        _itemImage.sprite = _itemData._itemSprite;
    }

    public void SelectSlot()
    {
        GetComponent<Image>().color = new Color(0, 0, 0, 1);

        if(_itemData == null)
        {

        }
    }
    public void UnSelectSlot()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
}
