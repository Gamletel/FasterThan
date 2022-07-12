using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalVars;

public class FinishController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            Vars.saveSystem.LoadNextLvl();
        }
    }
}
