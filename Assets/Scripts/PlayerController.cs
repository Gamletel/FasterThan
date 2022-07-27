using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource _sourse;
    [SerializeField] private AudioClip _wallPunch;
    private void Start()
    {
        _sourse = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            _sourse.PlayOneShot(_wallPunch);
        }
    }
}
//Не помню зачем
namespace Player
{
    public class Player : MonoBehaviour
    {
        public static GameObject player { get; private set; }
        private void Awake()
        {
            player = gameObject;
        }
    }
}
