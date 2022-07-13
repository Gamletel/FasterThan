using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVars.Vars;

public class FinishController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            saveSystem.LoadNextLvl();
        }
    }
}
