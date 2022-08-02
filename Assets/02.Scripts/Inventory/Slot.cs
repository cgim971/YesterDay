using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    [SerializeField] ItemData _itemData;
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
    [SerializeField] private Transform _itemInfo;

    private void Awake()
    {
        _itemInfo = GameManager.Instance.uiManager.INVENTORYMANAGER.ITEMINFO;
    }

    private void Start()
    {
        RefreshSlot();
    }

    public void RefreshSlot()
    {
        if (_itemData == null)
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

        if (_itemData == null)
        {
            _itemInfo.gameObject.SetActive(false);
        }
        else
        {
            _itemInfo.gameObject.SetActive(true);
            _itemInfo.GetComponent<ItemInfo>().SelectItem(_itemData);
        }
    }
    public void UnSelectSlot()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
}
