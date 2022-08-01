using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private ItemData _itemData;
    public ItemData ITEMDATA
    {
        get => _itemData;
        set
        {
            _itemData = value;
            _itemImage.GetComponent<SpriteRenderer>().sprite = _itemData._itemSprite;
        }
    }
    [SerializeField] private Transform _itemImage;

    Coroutine _coroutineItem;

    private void Start()
    {
        _itemImage = transform.Find("Frame").transform.Find("ItemImage");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_itemData == SaveManager.Instance.ITEM_X) { Debug.Log("안 돼!"); return; }

        if (other.CompareTag("Player"))
        {
            _coroutineItem = StartCoroutine(ItemInfo());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_coroutineItem != null)
            {
                StopCoroutine(_coroutineItem);
            }
        }
    }

    IEnumerator ItemInfo()
    {
        Debug.Log("F = 구매");
       
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));

        if (_itemData._isGet == true) { Debug.Log("이미 가지고 잇어"); yield break; }
        if (PlayerData.Instance.MONEY < _itemData._itemCost) { Debug.Log("돈이 부족해"); yield break; }

        _itemData._isGet = true;
        PlayerData.Instance.MONEY -= _itemData._itemCost;

        Debug.Log($"{_itemData._itemName} 구매 되었엉");
        ITEMDATA = SaveManager.Instance.ITEM_X;
    }
}
