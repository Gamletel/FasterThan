using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintModelController : MonoBehaviour
{
    [SerializeField] private GameObject _modelPref;
    [SerializeField] private Transform _transformForModel;
    private GameObject _model;
    private float speed = 15f;

    private void Start()
    {
        _model = Instantiate(_modelPref, _transformForModel) as GameObject;
        _model.gameObject.layer = 5;
    }


    private void Update()
    {
        RotateModel();
    }


    private void RotateModel()
    {
        _model.transform.Rotate(Vector3.left * Time.deltaTime * speed);
    }
}
