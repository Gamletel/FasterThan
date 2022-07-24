using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVars.Vars;

public class FinishController : MonoBehaviour
{
    private MenuPanelController _menuPanelController;
    private TimerController _timer;


    private void Start()
    {
        _menuPanelController = ui.GetComponent<MenuPanelController>();
        _timer = ui.GetComponent<TimerController>();
    }

    //Если игрок зашел в триггер, то показывается панель победы и вызывается метод остановки таймера
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            _menuPanelController.OpenWinPanel();
            _timer.StopTimer();
        }
    }
}
