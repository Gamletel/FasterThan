using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _door;
    private Material _material;

    private void Start()
    {
        RandomizeMaterial();
        _key.GetComponent<MeshRenderer>().material = _material;
        _door.GetComponent<MeshRenderer>().material = _material;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            DestroyKey();
            OpenDoor();
        }
        else
        {
            return;
        }
    }


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
