using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Goblin : Enemy
{
    [Header("Attack Property")]

    [SerializeField] private float _damage;

    [SerializeField] private Transform _attackPos;
    [SerializeField] private Vector2 _attackSize = Vector2.zero;

    protected override void Attack()
    {
        bool isAttack = _animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Goblin_Attack_1");
        if (isAttack == false)
        {
            _animator.SetTrigger("attack");
        }
    }

    public void Attack_1()
    {
        Attacking();
    }

    void Attacking()
    {
        Collider2D playerCol = Physics2D.OverlapBox(_attackPos.transform.position, _attackSize, 0, _playerLayerMask);

        if (playerCol != null)
        {
            playerCol.GetComponent<PlayerController>().TakeDamage(_damage);
        }
    }

}
