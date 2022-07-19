using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GlobalVars.Vars;

public class MenuPanelController : MonoBehaviour
{
    [SerializeField] private Text _loadLastLvlBtnText;
    [SerializeField] private Text _nameLvlText;
    [SerializeField] private Text _collectedCoinsText;
    private bool _playBackwards;
    private DOTweenAnimation _tween;

    private void Start()
    {
        _tween = GetComponent<DOTweenAnimation>();
        //Подписываемся на событие
        _collectedCoinsText.text = $"Монеток(): {CoinBank.LoadCoins()}";
        CoinBank.coinCollected += OnCoinCollected;
        //Загружаем из файла сохранения кол-во монеток и отображаем их
        
    }
    private void OnCoinCollected(int coinAmount)
    {
        _collectedCoinsText.text = $"Монеток: {coinAmount}";
    }
    public void MovePanel()
    {
        switch (!_playBackwards)
        {
            case true:
                _tween.DOPlayForward();
                _playBackwards = !_playBackwards;
                _loadLastLvlBtnText.text = "Закрыть";
                return;
            case false:
                _tween.DOPlayBackwards();
                _playBackwards = !_playBackwards;
                _loadLastLvlBtnText.text = "Меню";
                return;
        }
        
    }
    public void LoadMenuScene()
    {
        int menuSceneIndex = 0;
        SceneManager.LoadScene(menuSceneIndex);
    }
}
