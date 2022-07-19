using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinBank : MonoBehaviour
{
    //��� ������� ������� ������� ���� � ������� ����� �������
    public delegate void CoinHandler(int coinCost);
    public static event CoinHandler coinCollected;

    //����� �������
    public static int coinsAmount { get; private set; }

    //��������� �������
    public static void OnCoinCollected(int coinCost)
    {
        coinsAmount += coinCost;
        coinCollected?.Invoke(coinsAmount);
    }
    public static void SaveCoins()
    {
        coinCollected?.Invoke(coinsAmount);
    }
}