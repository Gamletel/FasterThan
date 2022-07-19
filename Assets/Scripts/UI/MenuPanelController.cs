using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPanelController : MonoBehaviour
{
    [SerializeField] private Text loadLastLvlBtnText;
    [SerializeField] private Text _nameLvlText;
    [SerializeField] private Text _collectedCoinsText;
    private bool _playBackwards;
    private DOTweenAnimation _tween;

    private void Start()
    {
        CoinBank.coinCollected += OnCoinCollected;
        _tween = GetComponent<DOTweenAnimation>();
    }
    private void OnCoinCollected(int coinAmount)
    {
        _collectedCoinsText.text = $"�������: {coinAmount}";
    }
    public void MovePanel()
    {
        switch (!_playBackwards)
        {
            case true:
                _tween.DOPlayForward();
                _playBackwards = !_playBackwards;
                loadLastLvlBtnText.text = "�������";
                return;
            case false:
                _tween.DOPlayBackwards();
                _playBackwards = !_playBackwards;
                loadLastLvlBtnText.text = "����";
                return;
        }
        
    }
    public void LoadMenuScene()
    {
        int menuSceneIndex = 0;
        SceneManager.LoadScene(menuSceneIndex);
    }
}
