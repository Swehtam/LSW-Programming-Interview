using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsDB : MonoBehaviour
{
    public string playerStartPoint;
    public int totalCoins;

    public string GetPlayerStartPoint()
    {
        return playerStartPoint;
    }

    public int GetPlayerTotalCoins()
    {
        return totalCoins;
    }

    /// <summary>
    /// Method called when player buys something.
    /// Check if has avaliable coins left to buy somethig,
    /// If the true is return than player can buy the thing that they want.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool SpendCoins(int value)
    {
        if(totalCoins > value)
        {
            totalCoins -= value;
            return true;
        }

        return false;
    }

    public void GainCoins(int value)
    {
        totalCoins += value;
    }
}
