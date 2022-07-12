using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPanelController : MonoBehaviour
{
    private bool _playBackwards;
    private DOTweenAnimation _tween;
    [SerializeField] private Text loadLastLvlBtnText;
    [SerializeField] private Text _nameLvlText;

    private void Start()
    {
        _tween = GetComponent<DOTweenAnimation>();
        _nameLvlText.text = $"�������: {SceneManager.GetActiveScene().buildIndex}";
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
