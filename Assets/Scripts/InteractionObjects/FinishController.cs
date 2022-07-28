using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private GameObject _ui;
    private MenuPanelController _menuPanelController;
    private TimerController _timer;


    private void Start()
    {
        _ui = GameObject.FindGameObjectWithTag("GameUI");
        _menuPanelController = _ui.GetComponent<MenuPanelController>();
        _timer = _ui.GetComponent<TimerController>();
    }

    //���� ����� ����� � �������, �� ������������ ������ ������ � ���������� ����� ��������� �������
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            _menuPanelController.OpenWinPanel();
            _timer.StopTimer();
        }
    }
}
