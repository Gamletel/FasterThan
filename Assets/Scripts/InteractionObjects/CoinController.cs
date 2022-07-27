using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinController : MonoBehaviour
{
    private int _coinCost = 2;


    //Если игрок зашел в триггер монетки, тогда добавляем монетку
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            AudioSource sourse = GetComponent<AudioSource>();
            sourse.PlayOneShot(sourse.clip);
            AddCoin(_coinCost);
        }
    }

    private void AddCoin(int coinCost)
    {
        CoinBank.OnCoinCollected(coinCost);
        Destroy(gameObject);
    }
}
