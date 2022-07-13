using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static GlobalVars.Vars;

public class LvlAutoSaver : MonoBehaviour
{

    private void Start()
    {
        saveSystem.SaveLastLvl();
    }
}
