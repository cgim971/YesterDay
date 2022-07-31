using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private float _speed;

    Rigidbody2D _rigid;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        StartCoroutine("MonsterAI");
    }

    public void StartMove()
    {
        StartCoroutine("MonsterAi");
    }
    public void StopMove()
    {
        StopCoroutine("MonsterAI");
    }

    IEnumerator MonsterAI()
    {
        int delay = Random.Range(2, 5);
        yield return new WaitForSeconds(delay);

        StartCoroutine("MonsterAI");
    }
}
