using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private List<Slot> _slots = new List<Slot>();
    [SerializeField] private Transform _itemInfo;
    public Transform ITEMINFO { get => _itemInfo; }

    [SerializeField] private GameObject _slot;
    [SerializeField] private Transform _slotParent;
    [SerializeField] private int _slotIndex;
    public int SLOTINDEX
    {
        get => _slotIndex;
        set
        {
            _slots[_slotIndex].SelectSlot();
            _slotIndex = value;
            _slots[_slotIndex].SelectSlot();
        }
    }

    public Slot SelectUsingSlot()
    {
        return _slots[_slotIndex];
    }

    private void Awake()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject newSlot = Instantiate(_slot, _slotParent);
            newSlot.GetComponent<Slot>().SLOTINDEX = i;

            foreach (ItemData itemData in SaveManager.Instance.ITEMDATALISTS)
            {
                if (itemData._isGet == true)
                {
                    if (itemData._slotIndex == i)
                    {
                        newSlot.GetComponent<Slot>().ITEMDATA = itemData;
                        break;
                    }
                }
            }

            _slots.Add(newSlot.GetComponent<Slot>());
        }
    }

    private void Update()
    {
        SelectSlot();
    }

    void SelectSlot()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_slotIndex - 3 < 0) return;

            _slots[_slotIndex].UnSelectSlot();
            _slotIndex -= 3;
            _slots[_slotIndex].SelectSlot();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_slotIndex + 3 > 8) return;
            _slots[_slotIndex].UnSelectSlot();
            _slotIndex += 3;
            _slots[_slotIndex].SelectSlot();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_slotIndex < 3)
            {
                if (_slotIndex == 0) return;
            }
            else if (_slotIndex < 6)
            {
                if (_slotIndex == 3) return;
            }
            else
            {
                if (_slotIndex == 6) return;
            }

            _slots[_slotIndex].UnSelectSlot();
            _slotIndex -= 1;
            _slots[_slotIndex].SelectSlot();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_slotIndex > 5)
            {
                if (_slotIndex == 8) return;
            }
            else if (_slotIndex > 2)
            {
                if (_slotIndex == 5) return;
            }
            else
            {
                if (_slotIndex == 2) return;
            }

            _slots[_slotIndex].UnSelectSlot();
            _slotIndex += 1;
            _slots[_slotIndex].SelectSlot();
        }
    }

}
