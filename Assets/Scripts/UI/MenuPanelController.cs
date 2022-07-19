using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GlobalVars.Vars;

public class MenuPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private Text _openMenuBtnText;
    [SerializeField] private Text _nameLvlText;
    [SerializeField] private Text _collectedCoinsText;
    private bool _playBackwards;
    private DOTweenAnimation _tween;

    private void Start()
    {
        _tween = _mainMenuPanel.GetComponent<DOTweenAnimation>();
        //������������� �� �������
        CoinBank.coinCollected += OnCoinCollected;
        //��������� ����������� �������� �������
        UpdateCoinsAmount(CoinBank.coinsAmount);
    }
    //���������� ��� ����� �������
    private void OnCoinCollected(int coinsAmount)
    {
        UpdateCoinsAmount(coinsAmount);
    }
    //��������� ���������� �������
    private void UpdateCoinsAmount(int coinsAmount)
    {
        _collectedCoinsText.text = $"�������: {coinsAmount}";
    }
    //��� ��������/�������� ������� ������
    public void MovePanel()
    {
        switch (!_playBackwards)
        {
            case true:
                _tween.DOPlayForward();
                _playBackwards = !_playBackwards;
                _openMenuBtnText.text = "�������";
                return;
            case false:
                _tween.DOPlayBackwards();
                _playBackwards = !_playBackwards;
                _openMenuBtnText.text = "����";
                return;
        }
        
    }
    //��������� id ������ �� ������ ������
    public void LoadMenuScene()
    {
        int menuSceneIndex = 0;
        SceneManager.LoadScene(menuSceneIndex);
    }
}
