using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private Animator _animator;
    private EnemyAttack _enemyAttack;

    [SerializeField] float hp = 10;

    [Header("Move Property")]
    private bool _isMove = false;
    [SerializeField] private float _speed;
    [SerializeField] private int _moveDir;

    [Header("Find Player Property")]
    [SerializeField] private LayerMask _playerLayerMask;
    private bool _isPlayer;
    private Transform _player;

    private Transform _pos;
    private Vector2 _findRange = new Vector2(8f, 2.5f);

    [Header("Death Property")]
    private bool _isDeath = false;

    [Header("Attack Property")]
    private bool _isAttacking = false;
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _attackDelay;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enemyAttack = GetComponent<EnemyAttack>();

        _pos = transform.Find("Pos");
        _isMove = true;

        StartCoroutine("MonsterAI");
    }

    private void Update()
    {
        FindPlayer();
        Chasing();
    }

    private void Chasing()
    {
        if (_isAttacking == false)
        {
            if (_isPlayer == true)
            {
                float distance = _player.position.x - transform.position.x;
                _moveDir = distance == 0 ? 0 : distance < 0 ? -1 : 1;

                if (Mathf.Abs(distance) < _attackRange)
                {
                    // attack
                    StartCoroutine(Attacking());
                }
                else
                {
                    _isMove = true;
                }
            }
        }
    }

    IEnumerator Attacking()
    {
        _isAttacking = true;
        _isMove = false;
        transform.localScale = new Vector2(_moveDir, 1);
        _enemyAttack.Attack();
        yield return new WaitForSeconds(_attackDelay);
        _isAttacking = false;
    }

    void FindPlayer()
    {
        Collider2D player = Physics2D.OverlapBox(_pos.position, _findRange, 0, _playerLayerMask);

        if (player != null)
        {
            _player = player.transform;

            _isPlayer = true;

            StopMove();
        }
        else
        {
            if (_isPlayer == true)
            {
                _isPlayer = false;
                StartMove();
            }
        }
    }

    public void StartMove()
    {
        _isMove = true;
        StartCoroutine("MonsterAI");
    }
    public void StopMove()
    {
        _isMove = false;
        StopCoroutine("MonsterAI");
    }

    IEnumerator MonsterAI()
    {
        _moveDir = Random.Range(-1, 2);
        int delay = Random.Range(2, 5);
        yield return new WaitForSeconds(delay);

        if (_isPlayer == false)
            StartCoroutine("MonsterAI");
    }

    private void FixedUpdate()
    {
        if (_isDeath == true)
        {
            return;
        }

        if (_isMove == false)
        {
            return;
        }

        if (_moveDir == 0)
        {
            _animator.SetBool("isRun", false);
        }
        else if (_moveDir == 1)
        {
            _animator.SetBool("isRun", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_moveDir == -1)
        {
            _animator.SetBool("isRun", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        _rigid.velocity = new Vector2(_moveDir, _rigid.velocity.y);
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0)
        {
            return;
        }

        hp -= damage;

        _animator.SetTrigger("hit");

        if (hp <= 0)
        {
            // death
            _isDeath = true;
            _animator.SetTrigger("death");
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
