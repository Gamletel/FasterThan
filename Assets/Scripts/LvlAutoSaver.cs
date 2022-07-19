using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static GlobalVars.Vars;

public class LvlAutoSaver : MonoBehaviour
{
    //Нужен для автоматического сохранения при загрузке нового уровня
    private void Start()
    {
        saveSystem.SaveLastLvl();
    }
}
