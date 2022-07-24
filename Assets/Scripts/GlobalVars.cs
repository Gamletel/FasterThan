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
        //������ � �������� ����������
        public static SaveSystem saveSystem = Camera.main.GetComponent<SaveSystem>();
        //������� ����� ���� � �����
        public static int sceneCount = SceneManager.sceneCountInBuildSettings;
        //�����
        public static GameObject player = GameObject.FindGameObjectWithTag("Player");
        //��������� ����
        public static GameObject ui = GameObject.FindGameObjectWithTag("GameUI");

    }
}

