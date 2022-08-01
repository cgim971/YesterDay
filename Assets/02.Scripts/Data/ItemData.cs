using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class ItemData : ScriptableObject
{
    public string objectName; //������Ʈ �̸�
    public Sprite sprite; //�̹���
    public int quantity; //�������� ����
    public bool stackable; //stackable����
    public float hp; //ü��
    public float damage; //���ݷ�
    public float def; //����
    public float speed; //�̵��ӵ�
    public float heal; //����
    public enum ItemType //������ ����(����, ���, ��ű�)
    {
        WEAPON,
        ARMOR,
        ACCESSORY
    }
    public ItemType itemType;
}
