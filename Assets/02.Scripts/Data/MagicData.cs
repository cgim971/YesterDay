using UnityEngine;

[CreateAssetMenu(fileName = "MagicData", menuName = "Assets/ScriptableObject/Magic")]
public class MagicData : ScriptableObject
{
    public MagicState _magicState;

    public string _name;
    public float _damage;

    public int _lv;

    public float _coolTime;
    public float _curentCoolTime;

    public AnimationClip _animationClip;
}
