using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private static PlayerData _instance;
    public static PlayerData Instance
    {
        get => _instance;
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

    }

    [SerializeField] private int _lv;
    [SerializeField] readonly private int _initialLv = 1;
    private readonly string _playerPrefsLvKey = "PlayerPrefsLv";
    public int LV
    {
        get => _lv;
        set
        {
            _lv = value;
            SaveManager.Instance.SaveData(_playerPrefsLvKey, _lv);
        }
    }

    [SerializeField] private int _money;
    [SerializeField] readonly private int _initialMoney = 0;
    private readonly string _playerPrefsMoneyKey = "PlayerPrefsMoney";
    public int MONEY
    {
        get => _money;
        set
        {
            _money = value;
            SaveManager.Instance.SaveData(_playerPrefsMoneyKey, _money);
        }
    }

    [SerializeField] private float _hp;
    [SerializeField] readonly private float _initialHp = 10;
    private readonly string _playerPrefsHpKey = "PlayerPrefsHp";
    public float HP
    {
        get => _hp;
        set
        {
            _hp = value;
            SaveManager.Instance.SaveData(_playerPrefsHpKey, _hp);
        }
    }

    [SerializeField] private float _attack;
    [SerializeField] readonly private float _initialAttack = 1;
    private readonly string _playerPrefsAttackKey = "PlayerPrefsAttack";
    public float ATTACK
    {
        get => _attack;
        set
        {
            _attack = value;
            SaveManager.Instance.SaveData(_playerPrefsAttackKey, _attack);
        }
    }

    [SerializeField] private float _defense;
    [SerializeField] readonly private float _initialDefense = 1;
    private readonly string _playerPrefsDefenseKey = "PlayerPrefsDefense";
    public float DEFENSE
    {
        get => _defense;
        set
        {
            _defense = value;
            SaveManager.Instance.SaveData(_playerPrefsDefenseKey, _defense);
        }
    }

    [SerializeField] private float _speed;
    [SerializeField] readonly private float _initialSpeed = 1;
    private readonly string _playerPrefsSpeedKey = "PlayerPrefsSpeed";
    public float SPEED
    {
        get => _speed;
        set
        {
            _speed = value;
            SaveManager.Instance.SaveData(_playerPrefsSpeedKey, _speed);
        }
    }

    [SerializeField] private float _blood;
    [SerializeField] readonly private float _initialBlood = 0;
    private readonly string _playerPrefsBloodKey = "PlayerPrefsBlood";
    public float BLOOD
    {
        get => _blood;
        set
        {
            _blood = value;
            SaveManager.Instance.SaveData(_playerPrefsBloodKey, _blood);
        }
    }


    public void LoadData()
    {
        LV = SaveManager.Instance.LoadIntData(_playerPrefsLvKey, _initialLv);
        MONEY = SaveManager.Instance.LoadIntData(_playerPrefsMoneyKey, _initialMoney);
        HP = SaveManager.Instance.LoadFloatData(_playerPrefsHpKey, _initialHp);
        ATTACK = SaveManager.Instance.LoadFloatData(_playerPrefsAttackKey, _initialAttack);
        DEFENSE = SaveManager.Instance.LoadFloatData(_playerPrefsDefenseKey, _initialDefense);
        SPEED = SaveManager.Instance.LoadFloatData(_playerPrefsSpeedKey, _initialSpeed);
        BLOOD = SaveManager.Instance.LoadFloatData(_playerPrefsBloodKey, _initialBlood);
    }

    public void ResetData()
    {
        SaveManager.Instance.DeleteData(_playerPrefsLvKey);
        SaveManager.Instance.DeleteData(_playerPrefsMoneyKey);
        SaveManager.Instance.DeleteData(_playerPrefsHpKey);
        SaveManager.Instance.DeleteData(_playerPrefsAttackKey);
        SaveManager.Instance.DeleteData(_playerPrefsDefenseKey);
        SaveManager.Instance.DeleteData(_playerPrefsSpeedKey);
        SaveManager.Instance.DeleteData(_playerPrefsBloodKey);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetData();
        }
    }
}
