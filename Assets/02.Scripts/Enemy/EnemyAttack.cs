using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private Animator _animator;

    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _playerLayerMask;

    [SerializeField] private Transform _attackPos;
    [SerializeField] private Vector2 _attackSize = Vector2.zero;

    private Vector2 _attack1Pos = new Vector2(0f, -0.2f);
    private Vector2 _attack1Size = new Vector2(5.8f, 3f);


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        bool isAttack = _animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Goblin_Attack_1");
        if (isAttack == false)
        {
            _animator.SetTrigger("attack");
        }
    }

    public void Attack_1()
    {
        bool isAttack = _animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Goblin_Attack_1");
        Debug.Log(isAttack);

        _attackPos.localPosition = _attack1Pos;
        _attackSize = _attack1Size;

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_attackPos.position, _attackSize);
    }
}
