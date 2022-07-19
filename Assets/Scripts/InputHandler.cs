using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //—читываем координаты движени€ пальца по экрану
    public Vector2 GetTouchDeltaPos()
    {
        if(Input.touchCount > 0)
            return Input.GetTouch(0).deltaPosition;
        return Vector2.zero;
    }

    //переменна€ дл€ того, чтобы было €сно есть касание или нет
    public bool isTouched()
    {
        if (Input.touchCount > 0)
            return true;
        else
            return false;

    }
}
