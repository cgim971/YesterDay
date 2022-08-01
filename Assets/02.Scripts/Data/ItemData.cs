using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class ItemData : ScriptableObject
{
    public string objectName; //오브젝트 이름
    public Sprite sprite; //이미지
    public int quantity; //아이템의 수량
    public bool stackable; //stackable상태
    public float hp; //체력
    public float damage; //공격력
    public float def; //방어력
    public float speed; //이동속도
    public float heal; //피흡
    public enum ItemType //아이템 종류(무기, 장비, 장신구)
    {
        WEAPON,
        ARMOR,
        ACCESSORY
    }
    public ItemType itemType;
}
