using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Assets/ScriptableObject/Weapon")]
public class WeaponData : ScriptableObject
{
    public WeaponState _weaponState;

    public string _name;
    public float _damage;

    public int _lv;
}
