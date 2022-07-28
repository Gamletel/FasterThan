using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GlobalVars.Vars;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private ParticleSystem _timerParticle;
    [SerializeField] private Image _img;
    private float _curTime;
    private Color _newColorForSprite;
    private Animator _timerParticleAnimator;
    
    private void Start()
    {
        _curTime = _maxTime;
        _newColorForSprite = _img.color;
        StartCoroutine(Timer());

        //Это чтобы анимация длилась столько, сколько длится уровень
        _timerParticleAnimator = _timerParticle.GetComponent<Animator>();
        _timerParticleAnimator.speed = 1 / _maxTime * 2; 
    }

    //Таймер (картинка) уменьшается в зависимости от оставшегося времени
    private IEnumerator Timer()
    {
        while(_curTime != 0)
        {
            yield return new WaitForSeconds(0.5f);
            _curTime--;
            float percent = _curTime / _maxTime;
            ChangeTimerImg(percent);
            ChangeTimerParticle(percent);
        }

        //Если время равно нулю, то включаем панель проигрыша и останавливаем таймер
        GetComponent<MenuPanelController>().OpenLosePanel();
        StopTimer();
    }

    //Изменение спрайта таймера
    private void ChangeTimerImg(float percent)
    {
        _newColorForSprite = new Color(1f, 0 + percent, 0 + percent);

        _img.color = _newColorForSprite;
        _img.fillAmount = percent;
    }

    //Изменение системы частиц таймера
    private void ChangeTimerParticle(float percent)
    {
        _timerParticle.startColor = new Color((1 - percent)*2, 0 + percent, 0f); 
    }

    //Для остановки таймера
    public void StopTimer()
    {
        StopAllCoroutines();
        _timerParticle.Stop();
        _timerParticleAnimator.StopPlayback();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<MovementHandler>().enabled = false;
        player.GetComponent<Rigidbody>().Sleep();
    }
}
