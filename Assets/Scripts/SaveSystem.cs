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
        if (File.Exists(_path))
        {
            _save = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));
        }
        else
        {
            SaveLastLvl();
        }
    }

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


        public void SaveLastLvl()
        {
        if (_save.lvlIndex < SceneManager.GetActiveScene().buildIndex)
        {
            _save.lvlIndex = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText(_path, JsonUtility.ToJson(_save.lvlIndex));
            Debug.Log($"Уровень {_save.lvlIndex} сохранен в прогресс!");
        }
        else
            Debug.Log("Сохранение не требуется!");

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
        }
    }
    [Serializable]
    public class SaveData
    {
        public int lvlIndex = -1;
    }
