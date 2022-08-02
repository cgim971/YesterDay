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
                    info += $"ü�� + {itemEffect.value}\n";
                    break;
                case ItemEffectType.ATK:
                    info += $"���ݷ� + {itemEffect.value}\n";
                    break;
                case ItemEffectType.DEF:
                    info += $"���� + {itemEffect.value}\n";
                    break;
                case ItemEffectType.SPD:
                    info += $"���ǵ� + {itemEffect.value}\n";
                    break;
                case ItemEffectType.BLOOD:
                    info += $"���� + {itemEffect.value}\n";
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
