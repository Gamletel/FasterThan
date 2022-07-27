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
        //Создаем рандомный цвет для пары дверь/ключ и назначаем им материалы
        RandomizeMaterial();
        _key.GetComponent<MeshRenderer>().material = _material;
        _door.GetComponent<MeshRenderer>().material = _material;
        _animator = GetComponent<Animator>();
        _sourse = GetComponent<AudioSource>();
    }

    //Когда игрок зашел в триггер ключ удаляется, а дверь открывается
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

    //Создаем рандомный материал
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
