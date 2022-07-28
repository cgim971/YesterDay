using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigid;

    [Header("Move Property")]
    [SerializeField] private float _speed;
    [SerializeField] private float _gravityScale;

    [SerializeField] private Transform _pos;

    [Header("Jump Property")]
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private int _jumpMaxCount;
    [SerializeField] private int _jumpCurrentCount;
    [SerializeField] private bool _isGround;

    [Header("Interaction Property")]
    [SerializeField] private bool _isLadder;
    [SerializeField] private float _ladderRadius;
    [SerializeField] private LayerMask _ladderLayerMask;

    [SerializeField] private float _teleportRadius;
    [SerializeField] private LayerMask _teleportLayerMask;


    [Header("Attack Property")]
    [SerializeField] private bool _isAttacking;


    [Header("Animation Property")]
    [SerializeField] private AnimationState _playerAnimationState;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _jumpCurrentCount = _jumpMaxCount;
        _rigid.gravityScale = _gravityScale;
    }

    private void Update()
    {
        Moving();
        Interaction();

        SpriteDirection();

        Attacking();
        UseSkill();

        Animation();
    }

    /// <summary>
    /// PlayerMove
    /// </summary>
    private void Moving()
    {
        float h = Input.GetAxisRaw("Horizontal");

        _rigid.velocity = new Vector2(h * _speed, _rigid.velocity.y);
        if (_rigid.velocity.x == 0)
        {
            _playerAnimationState = AnimationState.IDLE;
        }
        else
        {
            _playerAnimationState = AnimationState.RUN;
        }

        if (_isLadder)
        {
            float v = Input.GetAxisRaw("Vertical");

            _rigid.velocity = new Vector2(_rigid.velocity.x, v * _speed);
        }
        else
        {
            Jumping();
        }
    }


    /// <summary>
    /// PlayerJump
    /// </summary>
    private void Jumping()
    {
        _isGround = Physics2D.OverlapCircle(_pos.position, _checkRadius, _layerMask);

        if (_isGround == true && Input.GetKeyDown(KeyCode.Space) && _jumpCurrentCount > 0)
        {
            _rigid.velocity = Vector2.up * _jumpPower;
        }
        if (_isGround == false && Input.GetKeyDown(KeyCode.Space) && _jumpCurrentCount > 0)
        {
            _rigid.velocity = Vector2.up * _jumpPower;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _jumpCurrentCount--;
        }
        if (_isGround == true)
        {
            _jumpCurrentCount = _jumpMaxCount;
        }
    }


    private void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F)) Teleporting();
        Laddering();
    }

    private void Laddering()
    {
        _isLadder = Physics2D.OverlapCircle(new Vector2(_pos.position.x, _pos.position.y + _ladderRadius), _ladderRadius, _ladderLayerMask);

        if (_isLadder)
            _rigid.gravityScale = 0;
        else
            _rigid.gravityScale = _gravityScale;
    }

    private void Teleporting()
    {
        Collider2D teleportCol = Physics2D.OverlapCircle(transform.position, _teleportRadius, _teleportLayerMask);

        if (teleportCol != null)
        {
            transform.position = teleportCol.GetComponent<Teleport>().NextPosition;
        }
    }


    private void Attacking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isAttacking = true;

            _playerAnimationState = AnimationState.ATTACK;
        }
    }

    public void AttackEnd()
    {
        _isAttacking = false;
    }


    private void UseSkill()
    {
        if (_isAttacking) return;

        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }



    private void SpriteDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = transform.position;

        if (mousePosition.x != playerPosition.x)
        {
            Vector2 localScale = new Vector2(mousePosition.x > playerPosition.x ? 1 : -1, 1);
            transform.localScale = localScale;
        }
    }


    private void Animation()
    {
        if (_isAttacking) return;

        switch (_playerAnimationState)
        {
            case AnimationState.IDLE:
                AnimationIdle();
                break;
            case AnimationState.RUN:
                AnimationRun();
                break;
            case AnimationState.HIT:
                AnimationHit();
                break;
            case AnimationState.ATTACK:
                AnimationAttack();
                break;
        }
    }
    private void AnimationIdle()
    {
        _animator.SetBool("isRun", false);
    }
    private void AnimationRun()
    {
        _animator.SetBool("isRun", true);
    }
    private void AnimationHit()
    {
        _animator.SetTrigger("hit");
    }
    private void AnimationAttack()
    {
        _animator.SetTrigger("attack");
    }
}
