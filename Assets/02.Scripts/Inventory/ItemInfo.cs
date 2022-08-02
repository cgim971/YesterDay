using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemInfoText;
    Coroutine _coroutineChuck;
    public void SelectItem(ItemData itemData)
    {
        if (_coroutineChuck != null)
            StopCoroutine(_coroutineChuck);

        _coroutineChuck = StartCoroutine(Chuck());

        _itemImage.sprite = itemData._itemSprite;
        _itemName.text = itemData._itemName;

        string info = string.Empty;

        foreach (ItemEffect itemEffect in itemData._itemEffectList)
        {
            switch (itemEffect._itemEffectType)
            {
                case ItemEffectType.HP:
                    info += $"체력 + {itemEffect.value}\n";
                    break;
                case ItemEffectType.ATK:
                    info += $"공격력 + {itemEffect.value}\n";
                    break;
                case ItemEffectType.DEF:
                    info += $"방어력 + {itemEffect.value}\n";
                    break;
                case ItemEffectType.SPD:
                    info += $"스피드 + {itemEffect.value}\n";
                    break;
                case ItemEffectType.BLOOD:
                    info += $"흡혈 + {itemEffect.value}\n";
                    break;
            }
        }

        _itemInfoText.text = info;
    }

    private IEnumerator Chuck()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.G) == true);
        Slot slot = GameManager.Instance.uiManager.INVENTORYMANAGER.SelectUsingSlot();
        if (slot.ITEMDATA != null)
        {
            slot.ITEMDATA._isGet = false;
            slot.ITEMDATA = null;
            GameManager.Instance.uiManager.INVENTORYMANAGER.ITEMINFO.gameObject.SetActive(false);
        }
    }
}
