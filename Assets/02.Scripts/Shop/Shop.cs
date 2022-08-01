using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] List<Item> _items = new List<Item>();
    [SerializeField] private List<ItemData> _itemDatas = new List<ItemData>();


    private void Start()
    {
        ItemInfoSet();
    }

    public void ItemInfoSet()
    {
        _itemDatas = SaveManager.Instance.ITEMDATALISTS;


        bool[] isSet = new bool[_itemDatas.Count];

        foreach (Item item in _items)
        {
            GetItem(item);
        }
    }

    public void GetItem(Item item)
    {
        List<ItemData> items = new List<ItemData>();
        if (GetItemCount() == 0)
        {
            Debug.Log("구매 할 수 있는 아이템이 없는뎅");
            item.ITEMDATA = SaveManager.Instance.ITEM_X;
            return;
        }

        int itemTier = Random.Range(0, 100);

        if (itemTier < 1) itemTier = 1;
        else if (itemTier < 4) itemTier = 2;
        else if (itemTier < 16) itemTier = 3;
        else if (itemTier < 38) itemTier = 4;
        else itemTier = 5;

        foreach (ItemData itemData in _itemDatas)
        {
            if (itemData._itemTier == itemTier)
            {
                if (itemData._isGet == false)
                {
                    items.Add(itemData);
                }
            }
        }

        if (items.Count <= 0)
        {
            GetItem(item);
            return;
        }

        int index = Random.Range(0, items.Count);
        item.ITEMDATA = items[index];
        return;
    }

    public int GetItemCount()
    {
        int itemCount = 0;

        for (int index = 0; index < _itemDatas.Count; index++)
        {
            if (_itemDatas[index]._isGet == false)
            {
                itemCount++;
            }
        }

        return itemCount;
    }
}
