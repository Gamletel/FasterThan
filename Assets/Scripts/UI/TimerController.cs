using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    private float _curTime;
    private Image _img;

    private void Start()
    {
        _img = GetComponent<Image>();
        _curTime = _maxTime;
        StartCoroutine(Timer());
    }

    //Таймер (картинка) уменьшается в зависимости от оставшегося времени
    private IEnumerator Timer()
    {
        while(_curTime != 0)
        {
            yield return new WaitForSeconds(1f);
            _curTime--;
            float percent = _curTime / _maxTime;
            _img.fillAmount = percent;
            _img.color = new Color(255, 255 * percent, 255 * percent, 255);
        }
        //Если время равно нулю, перезагружаем сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
