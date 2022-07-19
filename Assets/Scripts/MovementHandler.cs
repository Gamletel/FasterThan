using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class MovementHandler : MonoBehaviour
{
    private Rigidbody _rb;
    private InputHandler _input;
    private float _speed = 0.4f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputHandler>();
    }


    void FixedUpdate()
    {
        MoveBall();
    }


    private void MoveBall()
    {
        if (_input.isTouched())
        {
            Vector3 currDeltaPos = new Vector3(_input.GetTouchDeltaPos().x, 0, _input.GetTouchDeltaPos().y);
            currDeltaPos *= _speed;
            _rb.AddForce(currDeltaPos, ForceMode.Force);
        }
    }
}