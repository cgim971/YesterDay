using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Assets/ScriptableObject/Weapon")]
public class WeaponData : ScriptableObject
{

    public string _name;
    public float _damage;

    public int _lv;

}
