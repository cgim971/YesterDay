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

    [Header("Jump Property")]
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform _jumpPos;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private int _jumpMaxCount;
    [SerializeField] private int _jumpCurrentCount;
    [SerializeField] private bool _isGround;

    [Header("Animation Property")]
    [SerializeField] private AnimationState _playerAnimationState;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _jumpCurrentCount = _jumpMaxCount;
    }

    private void Update()
    {
        Move();
        Jump();

        SpriteDirection();

        Animation();
    }

    /// <summary>
    /// PlayerMove
    /// </summary>
    private void Move()
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
    }

    /// <summary>
    /// PlayerJump
    /// </summary>
    private void Jump()
    {
        _isGround = Physics2D.OverlapCircle(_jumpPos.position, _checkRadius, _layerMask);

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
}
