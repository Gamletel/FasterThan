using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    private void Update()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y + 1, _player.position.z);
    }
}
