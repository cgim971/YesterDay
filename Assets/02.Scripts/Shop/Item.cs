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

    public GameObject ui;
    public Transform canvas;
    GameObject obj;

    private void Start()
    {
        _itemImage = transform.Find("Frame").transform.Find("ItemImage");
        obj = Instantiate(ui, canvas);
        obj.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_itemData == SaveManager.Instance.ITEM_X) { Debug.Log("�� ��!"); return; }

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
                obj.SetActive(false);
                StopCoroutine(_coroutineItem);
            }
        }
    }

    IEnumerator ItemInfo()
    {
        Debug.Log("F = ����");
        
        obj.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(transform.position);
        obj.SetActive(true);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));

        if (_itemData._isGet == true) { Debug.Log("�̹� ������ �վ�"); yield break; }
        if (PlayerData.Instance.MONEY < _itemData._itemCost) { Debug.Log("���� ������"); yield break; }

        obj.SetActive(false);

        _itemData._isGet = true;
        PlayerData.Instance.MONEY -= _itemData._itemCost;

        Debug.Log($"{_itemData._itemName} ���� �Ǿ���");
        ITEMDATA = SaveManager.Instance.ITEM_X;
    }
}
