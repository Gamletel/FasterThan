using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;

namespace GlobalVars
{
    public class Vars : MonoBehaviour
    {
        //скрипт с системой сохранений
        public static SaveSystem saveSystem = Camera.main.GetComponent<SaveSystem>();
        //сколько всего сцен в билде
        public static int sceneCount = SceneManager.sceneCountInBuildSettings;

    }
}

