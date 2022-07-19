using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVars.Vars;
public class CoinBank : MonoBehaviour
{
    //ПРИ ПОДБОРЕ смотрим сколько было и сколько стало монеток
    public delegate void CoinHandler(int coinCost);
    public static event CoinHandler coinCollected;

    //Всего монеток
    public static int coinsAmount { get; private set; }


    //Добавляем монетки
    public static void OnCoinCollected(int coinCost)
    {
        coinsAmount += coinCost;
        saveSystem.SaveCoins(coinCost);
        coinCollected?.Invoke(coinsAmount);  
    }
}