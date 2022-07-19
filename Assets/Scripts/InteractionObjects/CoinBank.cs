using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVars.Vars;
public class CoinBank : MonoBehaviour
{
    //��� ������� ������� ������� ���� � ������� ����� �������
    public delegate void CoinHandler(int coinCost);
    public static event CoinHandler coinCollected;

    //����� �������
    public static int coinsAmount { get; private set; }

    //��������� � ��������� ����������� ���������� �������
    public static int LoadCoins()
    {
        coinsAmount = saveSystem.LoadCoins(coinsAmount);
        return coinsAmount;
    }

    //��������� �������
    public static void OnCoinCollected(int coinCost)
    {
        coinsAmount += coinCost;
        saveSystem.SaveCoins(coinCost);
        coinCollected?.Invoke(coinsAmount);  
    }
}