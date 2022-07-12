using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GlobalVars;

public class LvlAutoSaver : MonoBehaviour
{

    private void Start()
    {
        Vars.saveSystem.SaveLastLvl();
    }
}
