using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector2 _nextPosition;

    public Vector2 NextPosition
    {
        get { return _nextPosition; }
    }

}
