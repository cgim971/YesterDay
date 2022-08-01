using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigid;
    protected Animator _animator;

    [SerializeField] protected float hp = 10;

    [Header("Move Property")]
    protected bool _isMove = false;
    [SerializeField] protected float _speed;
    [SerializeField] private int _moveDir;
    public int MoveDir
    {
        get => _moveDir;
        set => _moveDir *= value;
    }
    Coroutine CoroutineMove;

    [Header("Find Player Property")]
    [SerializeField] protected LayerMask _playerLayerMask;
    private bool _isPlayer;
    private Transform _player;

    [SerializeField] private Transform _pos;
    [SerializeField] protected Vector2 _findRange;

    [Header("Death Property")]
    protected bool _isDeath = false;

    [Header("Attack Property")]
    private bool _isAttacking = false;
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _attackDelay;
    Coroutine CoroutineAttack;


    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _pos = transform.Find("Pos");
        _isMove = true;

        CoroutineMove = StartCoroutine(MonsterAI());
    }

    private void Update()
    {
        if (_isDeath == true)
        {
            return;
        }

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
                    StartAttack();
                }
                else
                {
                    _isMove = true;
                }
            }
        }
    }

    protected void StartAttack()
    {
        CoroutineAttack = StartCoroutine(Attacking());
    }
    protected void StopAttack()
    {

        if (CoroutineAttack != null)
        {
            StopCoroutine(CoroutineAttack);
        }

        _isAttacking = false;
    }

    IEnumerator Attacking()
    {
        _isAttacking = true;
        _isMove = false;
        transform.localScale = new Vector2(_moveDir, 1);
        Attack();
        yield return new WaitForSeconds(_attackDelay);
        _isAttacking = false;
    }

    protected abstract void Attack();


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_pos.position, _findRange);
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
        CoroutineMove = StartCoroutine(MonsterAI());
    }
    public void StopMove()
    {
        _isMove = false;

        if (CoroutineMove != null)
        {
            StopCoroutine(CoroutineMove);
        }
    }

    IEnumerator MonsterAI()
    {
        _moveDir = Random.Range(-1, 2);
        int delay = Random.Range(2, 5);
        yield return new WaitForSeconds(delay);

        if (_isPlayer == false)
            StartMove();
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

    public abstract void TakeDamage(float damage);


    public void Death()
    {
        Debug.Log($"{transform.name} Destroy");

        Destroy(this.gameObject);
    }
}
