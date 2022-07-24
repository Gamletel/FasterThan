using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintModelController : MonoBehaviour
{
    [SerializeField] private GameObject _modelPref;
    [SerializeField] private Transform _transformForModel;
    private GameObject _model;
    private readonly float _speed = 60f;

    private void Start()
    {
        _model = Instantiate(_modelPref, _transformForModel);
        _model.isStatic = false;
        _model.layer = 5;
    }


    private void Update()
    {
        RotateModel();
    }


    private void RotateModel()
    {
        _model.transform.Rotate(Vector3.down * Time.deltaTime * _speed);
    }
}
