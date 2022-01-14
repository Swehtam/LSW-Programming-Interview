using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGarmentDB : MonoBehaviour
{
    public int playerShirtID;
    public int playerPantsID;

    public int[] playerOwnedShirtsID;
    public int[] playerOwnedPantsID;

    public int GetShirtID()
    {
        return playerShirtID;
    }

    public int GetPantsID()
    {
        return playerPantsID;
    }

    public int[] GetOwnedShirtsID()
    {
        return playerOwnedShirtsID;
    }

    public int[] GetOwnedPantsID()
    {
        return playerOwnedPantsID;
    }
}
