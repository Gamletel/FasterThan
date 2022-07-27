using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _door;
    private Material _material;
    private Animator _animator;
    private AudioSource _sourse;

    private void Start()
    {
        //������� ��������� ���� ��� ���� �����/���� � ��������� �� ���������
        RandomizeMaterial();
        _key.GetComponent<MeshRenderer>().material = _material;
        _door.GetComponent<MeshRenderer>().material = _material;
        _animator = GetComponent<Animator>();
        _sourse = GetComponent<AudioSource>();
    }

    //����� ����� ����� � ������� ���� ���������, � ����� �����������
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            DestroyKey();
            OpenDoor();
            _animator.SetTrigger("KeyPickedUp");
            _sourse.PlayOneShot(_sourse.clip);
        }
        else
        {
            return;
        }
    }

    //������� ��������� ��������
    private void RandomizeMaterial()
    {
        Color color = new Color(Random.value, Random.value, Random.value, 1);
        _material = new Material(Shader.Find("Standard"));
        _material.color = color;
    }


    private void DestroyKey()
    {
        Destroy(_key);
    }
    

    private void OpenDoor()
    {
        _door.GetComponent<Animator>().SetTrigger("Open");
    }
}
