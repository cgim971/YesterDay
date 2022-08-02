using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveManager : MonoBehaviour
{
    private static SaveManager _instance;
    public static SaveManager Instance
    {
        get => _instance;
    }

    [SerializeField] private List<ItemData> _itemDataLists = new List<ItemData>();
    public List<ItemData> ITEMDATALISTS
    {
        get => _itemDataLists;
    }
    [SerializeField] private ItemData _item_x;
    public ItemData ITEM_X
    {
        get => _item_x;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        PlayerData.Instance.LoadData();
    }



    public int LoadIntData(string str, int data)
    {
        return PlayerPrefs.GetInt(str, data);
    }
    public float LoadFloatData(string str, float data)
    {
        return PlayerPrefs.GetFloat(str, data);
    }
    public string LoadStringData(string str, string data)
    {
        return PlayerPrefs.GetString(str, data);
    }
    public Vector2 LoadVector2Data(string str)
    {
        Vector2 data = JsonConvert.DeserializeObject<Vector2>(str);
        return data;
    }
  

    public void SaveData(string str, int data)
    {
        PlayerPrefs.SetInt(str, data);
    }
    public void SaveData(string str, float data)
    {
        PlayerPrefs.SetFloat(str, data);
    }
    public void SaveData(string str, string data)
    {
        PlayerPrefs.SetString(str, data);
    }
    public void SaveData(string str, Vector2 data)
    {
        string jsonStr = JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(str, jsonStr);
    }

    public void DeleteData(string str)
    {
        PlayerPrefs.DeleteKey(str);
    }

}
