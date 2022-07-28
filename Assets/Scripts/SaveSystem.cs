using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalVars.Vars;

[RequireComponent(typeof(LvlAutoSaver))]
    public class SaveSystem : MonoBehaviour
    {
        private SaveData _save = new SaveData();
        private string _path;

        private void Awake()
        {
    #if UNITY_ANDROID && !UNITY_EDITOR
            _path = Path.Combine(Application.persistentDataPath, "Save.json");
    #else
            _path = Path.Combine(Application.dataPath, "Save.json");
    #endif
            //���� ��� ���� ����������� ����, �� ������ ��� �
            //��������� ���������� �������
            if (File.Exists(_path))
            {
                _save = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));
                CoinBank.LoadCoins();
            }
            else
            {
                SaveLastLvl();
            }
        }

        //��� �������� ���������� ��������� ��������
#if UNITY_ANDROID && !UNITY_EDITOR
        private void OnApplicationPause(bool pause)
        {
        if(pause) File.WriteAllText(_path, JsonUtility.ToJson(_save));
        }
#endif
            private void OnApplicationQuit()
            {
                File.WriteAllText(_path, JsonUtility.ToJson(_save));
            }

            //���������� �������
            public void SaveCoins(int coinCost)
            {
                _save.coinsAmount += coinCost;
                File.WriteAllText(_path, JsonUtility.ToJson(_save.coinsAmount));
                Debug.Log($"����������� ����� �������: {_save.coinsAmount}");
            }

            //�������� ������������ ���������� �������
            public int LoadCoins(int coinsAmount)
            {
                coinsAmount = _save.coinsAmount;
                Debug.Log($"��������� ������� �� �����: {coinsAmount}");
                return coinsAmount;
            }


            public void SaveLastLvl()
            {
                if (_save.lvlIndex < SceneManager.GetActiveScene().buildIndex)
                {
                    _save.lvlIndex = SceneManager.GetActiveScene().buildIndex;
                    File.WriteAllText(_path, JsonUtility.ToJson(_save.lvlIndex));
                    Debug.Log($"������� {_save.lvlIndex} �������� � ��������!");
                }
                else
                    Debug.Log("���������� �� ���������!");
            }


            public void LoadLastSavedLvl()
            {
                SceneManager.LoadScene(_save.lvlIndex++);
            }


            public void LoadNextLvl()
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextSceneIndex <= sceneCount-1)
                    SceneManager.LoadScene(nextSceneIndex);
                else
                    SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }


            public void RestartLvl()
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }


            public void ReadData(int maxLvl, int coinsAmount)
            {
                maxLvl = _save.lvlIndex;
                coinsAmount = _save.coinsAmount;
            }
    }

    [Serializable]
    public class SaveData
    {
        public int lvlIndex = -1;
        public int coinsAmount = 0;
    }
