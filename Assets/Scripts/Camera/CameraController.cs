using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    //����������� ������
    [SerializeField] private GameObject _globalCam;
    [SerializeField] private GameObject _playerCam;
    private CinemachineVirtualCamera _playerVCam;

    //���� ���������� ����� true, �� ������ �� ������������ �� �����
    private bool _playerCamEnabled;

    private float _camStartDistance;
    private float _camCurDistance;

    //��� ��� ����������� ��������� ����� ����� ��������
    private float _touchDistance;
    private float _startTouchDistance;
    private Touch _touch0;
    private Touch _touch1;

    private void Start()
    {
        _playerVCam = _playerCam.GetComponent<CinemachineVirtualCamera>();
        //��������� �������� ��������� ������
        _camStartDistance = _playerVCam.m_Lens.OrthographicSize;

        _playerVCam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Input.touchCount == 2)
        {
            _touch0 = Input.GetTouch(0);
            _touch1 = Input.GetTouch(1);
            if (_startTouchDistance == 0)
            {  
                //������� ��������� ��������� ����� ���������
                _startTouchDistance = Mathf.Abs(Vector2.Distance(_touch0.position, _touch1.position));
            }
            else
            {
                //���� ���� �� ������� ���������
                if (_touch0.deltaPosition != Vector2.zero || _touch1.deltaPosition != Vector2.zero)
                {
                    CheckDistance();
                }
                //���� ���� �� ������ ������, ����� ����������� ����
                if (_touch0.phase == TouchPhase.Ended || _touch1.phase == TouchPhase.Ended)
                {
                    _startTouchDistance = 0;
                }
            }
            
        }
    }

    private void CheckDistance()
    {
        //������� ��������� ����� �������� � ��������� ������ ��������� ��� �����
        _touchDistance = Mathf.Abs(Vector2.Distance(_touch0.position, _touch1.position));
        float distanceToIncrease = _startTouchDistance;
        float distanceToReduce = _startTouchDistance;

        //�����������
        if(_touchDistance > distanceToIncrease)
        {
            //�������� ������ ��� �������
            _playerCamEnabled = true;
            _playerCam.SetActive(_playerCamEnabled);

            //���������, ����� �� ���������� ������
            _playerVCam.m_Lens.OrthographicSize -= 0.1f;
            _camCurDistance = _playerVCam.m_Lens.OrthographicSize;
            if (_camCurDistance <= 5f)
            {
                _playerVCam.m_Lens.OrthographicSize = 5;
            }
        }
        //���������
        if(_touchDistance < distanceToReduce)
        {       
            //���������, ����� �� �������� ������
            if (_camCurDistance <= 15f)
            {
                _playerVCam.m_Lens.OrthographicSize += 0.1f;
                _camCurDistance = _playerVCam.m_Lens.OrthographicSize;
            }
            //��������� ������ ��� �������
            else
            {
                _playerCamEnabled = false;
                _playerCam.SetActive(_playerCamEnabled);
            }
        }
    }
}