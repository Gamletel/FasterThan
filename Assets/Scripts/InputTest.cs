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
                //��� �� ����� (����� ��������� � ��� �� ����� ��� � ������)
                if(touch.phase == TouchPhase.Ended && touch.rawPosition == touch.position)
                {
                        Debug.Log("��� �� �����!");
                }

                //��� ����������� �������
                 if (touch.phase == TouchPhase.Moved)
                 {
                     if (touch.deltaPosition.x >= 100 && Mathf.Abs(touch.deltaPosition.y) <= 50)
                     {
                         Debug.Log("����� ������!");
                     }
                     if (touch.deltaPosition.x <= -100 && Mathf.Abs(touch.deltaPosition.y) <= 50)
                     {
                         Debug.Log("����� �����!");
                     }
                 }
                
                return;

            case 2:
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);
                if (_startDistance == 0)
                {
                    CheckFirstPos(touch0, touch1);
                }
                if (touch0.deltaPosition != Vector2.zero)
                {
                    CheckDistance(touch0, touch1);
                }
                if (touch0.phase == TouchPhase.Ended)
                {
                    Debug.LogWarning("���������� ����� ��������: ");
                    CheckDistance(touch0, touch1);
                }
                return;
        }
    }

    private void CheckFirstPos(Touch touch0, Touch touch1)
    {
        _startDistance = Mathf.Abs(Vector3.Distance(touch0.position, touch1.position));
        Debug.LogWarning(_startDistance);
    }

    private void CheckDistance(Touch touch0, Touch touch1)
    {
        _curDistance = Mathf.Abs(Vector3.Distance(touch0.position, touch1.position));
        float neededDistanceToIncrease = _startDistance + (_startDistance / 100 * 10);
        float neededDistanceToReduce = _startDistance - (_startDistance / 100 * 10);
        if (_curDistance > neededDistanceToIncrease)
        {
            Debug.LogWarning("���� ����������");
        }
        if (_curDistance < neededDistanceToReduce)
        {
            Debug.LogWarning("���� ����������");
        }
    }
}
