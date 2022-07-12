using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalVars
{
    public class Vars : MonoBehaviour
    {
        //скрипт с системой сохранений
        public static SaveSystem saveSystem = Camera.main.GetComponent<SaveSystem>();

        public static int sceneCount = SceneManager.sceneCountInBuildSettings;
    }
}

