using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private float _startDistance = 0;
    private float _curDistance;
    void Update()
    {
        var touchCount = Input.touchCount;
        switch(touchCount)
        {
            case 0:
                return;

            case 1:
                Touch touch = Input.GetTouch(0);
                //Тап на месте (палец отпустили в том же месте где и нажали)
                if(touch.phase == TouchPhase.Ended && touch.rawPosition == touch.position)
                {
                        Debug.Log("Тап на месте!");
                }

                //Для бесконечных свайпов
                // if (touch.phase == TouchPhase.Moved)
                // {
                //     if (touch.deltaPosition.x >= 100 && Mathf.Abs(touch.deltaPosition.y) <= 50)
                //     {
                //         Debug.Log("Свайп вправо!");
                //     }
                //     if (touch.deltaPosition.x <= -100 && Mathf.Abs(touch.deltaPosition.y) <= 50)
                //     {
                //         Debug.Log("Свайп влево!");
                //     }
                // }
                Touch touch0 = Input.GetTouch(0);
                Vector2 touch1 = new Vector2(150, 150);
                if(_startDistance == 0)
                {
                    CheckFirstPos(touch0, touch1);
                }
                if(touch0.deltaPosition != Vector2.zero)
                {
                    CheckDistance(touch0, touch1);
                }
                if (touch0.phase == TouchPhase.Ended)
                {
                    Debug.LogWarning("Расстояние между пальцами: ");
                    CheckDistance(touch0, touch1);
                }
                return;

            case 2:
                
                return;
        }
    }
    private void CheckFirstPos(Touch touch0, Vector2 touch1)
    {
        _startDistance = Mathf.Abs(Vector3.Distance(touch0.position, touch1));
        Debug.LogWarning(_startDistance);
    }
    private void CheckDistance(Touch touch0, Vector2 touch1)
    {
        _curDistance = Mathf.Abs(Vector3.Distance(touch0.position, touch1));
        float neededDistanceToIncrease = _startDistance + (_startDistance / 100 * 10);
        float neededDistanceToReduce = _startDistance - (_startDistance / 100 * 10);
        if (_curDistance > neededDistanceToIncrease)
        {
            Debug.LogWarning("Жест увеличение");
        }
        if (_curDistance < neededDistanceToReduce)
        {
            Debug.LogWarning("Жест уменьшение");
        }
    }
}
