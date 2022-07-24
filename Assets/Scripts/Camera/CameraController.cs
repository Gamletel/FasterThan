using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    //Виртуальные камеры
    [SerializeField] private GameObject _globalCam;
    [SerializeField] private GameObject _playerCam;
    private CinemachineVirtualCamera _playerVCam;

    //Если переменная равна true, то камера не переключится на общую
    private bool _playerCamEnabled;

    private float _camStartDistance;
    private float _camCurDistance;

    //Все для определения дистанции между двумя пальцами
    private float _touchDistance;
    private float _startTouchDistance;
    private Touch _touch0;
    private Touch _touch1;

    private void Start()
    {
        _playerVCam = _playerCam.GetComponent<CinemachineVirtualCamera>();
        //Начальное значение дальности камеры
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
                //Считаем начальную дистанцию между касаниями
                _startTouchDistance = Mathf.Abs(Vector2.Distance(_touch0.position, _touch1.position));
            }
            else
            {
                //Если один ищ пальцев двигается
                if (_touch0.deltaPosition != Vector2.zero || _touch1.deltaPosition != Vector2.zero)
                {
                    CheckDistance();
                }
                //Если один из пальец убрали, тогда заканчиваем жест
                if (_touch0.phase == TouchPhase.Ended || _touch1.phase == TouchPhase.Ended)
                {
                    _startTouchDistance = 0;
                }
            }
            
        }
    }

    private void CheckDistance()
    {
        //Считаем дистанцию между пальцами и вычисляем нужную дистанцию для жеста
        _touchDistance = Mathf.Abs(Vector2.Distance(_touch0.position, _touch1.position));
        float distanceToIncrease = _startTouchDistance;
        float distanceToReduce = _startTouchDistance;

        //Приближение
        if(_touchDistance > distanceToIncrease)
        {
            //Включаем камеру над игроком
            _playerCamEnabled = true;
            _playerCam.SetActive(_playerCamEnabled);

            //Проверяем, можем ли приближать камеру
            _playerVCam.m_Lens.OrthographicSize -= 0.1f;
            _camCurDistance = _playerVCam.m_Lens.OrthographicSize;
            if (_camCurDistance <= 5f)
            {
                _playerVCam.m_Lens.OrthographicSize = 5;
            }
        }
        //Отдаление
        if(_touchDistance < distanceToReduce)
        {       
            //Проверяем, можем ли отдалять камеру
            if (_camCurDistance <= 15f)
            {
                _playerVCam.m_Lens.OrthographicSize += 0.1f;
                _camCurDistance = _playerVCam.m_Lens.OrthographicSize;
            }
            //Выключаем камеру над игроком
            else
            {
                _playerCamEnabled = false;
                _playerCam.SetActive(_playerCamEnabled);
            }
        }
    }
}