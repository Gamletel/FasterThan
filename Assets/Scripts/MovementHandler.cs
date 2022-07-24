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

    //Если получаем касание, тогда начинаем добавлять силу к игроку в соответствующую сторону
    void FixedUpdate()
    {
        if (_input.isTouched())
        {
            MoveBall();
        }
    }

    //Смотрим в каком направлении прилагать силу и применяем эту силу
    private void MoveBall()
    {
            Vector3 currDeltaPos = new Vector3(_input.GetTouchDeltaPos().x, 0, _input.GetTouchDeltaPos().y);
            currDeltaPos *= _speed;
            _rb.AddForce(currDeltaPos, ForceMode.Force);

    }
}