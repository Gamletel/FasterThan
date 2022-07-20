using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

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
