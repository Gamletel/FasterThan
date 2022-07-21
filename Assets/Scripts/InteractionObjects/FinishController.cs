using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVars.Vars;

public class FinishController : MonoBehaviour
{
    private MenuPanelController _menuPanelController;
    private void Start()
    {
        _menuPanelController = GameObject.Find("[INTERFACE]").GetComponent<MenuPanelController>();
    }
    //Если игрок зашел в триггер, то показывается панель победы
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            _menuPanelController.OpenWinPanel();
            Time.timeScale = 0;
        }
    }
}
