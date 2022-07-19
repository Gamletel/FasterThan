using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVars.Vars;

public class FinishController : MonoBehaviour
{
    //Если игрок зашел в триггер, то загружаем следующий уровень
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            saveSystem.LoadNextLvl();
        }
    }
}
