using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    Coroutine _coroutineUsingInventory;
    public bool _usingInventory;
    public GameObject _inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _usingInventory = !_usingInventory;

            if (_usingInventory == true)
            {
                Debug.Log("Inventory ����");
                Time.timeScale = 0;
                _inventory.SetActive(true);
                _inventory.GetComponent<InventoryManager>().SLOTINDEX = 0;
            }
            else
            {
                Debug.Log("Inventory ����");
                Time.timeScale = 1;
                _inventory.SetActive(false);
            }
        }
    }


}
