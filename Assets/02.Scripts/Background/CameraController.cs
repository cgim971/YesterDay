using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{

    GameObject player; void Start() { player = GameObject.Find("Player"); }
    void Update() { Vector3 playerPos = player.transform.position; transform.position = new Vector3(playerPos.x, playerPos.y + 2, transform.position.z); }
    
}
