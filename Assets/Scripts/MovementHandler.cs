using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class MovementHandler : MonoBehaviour
{
    private InputHandler _input;
    private float _speed = 0.4f;
    void Start()
    {
        _input = GetComponent<InputHandler>();
    }
    void Update()
    {
        MoveBall();
    }
    private void MoveBall()
    {
        if (_input.isTouched())
        {
            Vector2 currDeltaPos = _input.GetTouchDeltaPos();
            currDeltaPos = currDeltaPos * _speed;
            Physics.gravity = new Vector3(currDeltaPos.x, 0 ,currDeltaPos.y);
        }
    }
}
