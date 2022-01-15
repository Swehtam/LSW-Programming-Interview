using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGarmentDB : MonoBehaviour
{
    public int playerShirtID;
    public int playerPantsID;

    public List<int> playerOwnedShirtsID = new List<int>();
    public List<int> playerOwnedPantsID = new List<int>();

    public int GetShirtID()
    {
        return playerShirtID;
    }

    public int GetPantsID()
    {
        return playerPantsID;
    }

    public List<int> GetOwnedShirtsID()
    {
        return playerOwnedShirtsID;
    }

    public List<int> GetOwnedPantsID()
    {
        return playerOwnedPantsID;
    }

    public void AddNewSkin(Skins skin)
    {
        switch (skin.garment)
        {
            case Garment.Pants:
                playerPantsID = skin.skinID;
                playerOwnedPantsID.Add(skin.skinID);
                break;

            case Garment.Shirt:
                playerShirtID = skin.skinID;
                playerOwnedShirtsID.Add(skin.skinID);
                break;
        }
    }

    public bool CheckIfOwns(int id)
    {
        return (playerOwnedShirtsID.Contains(id) || playerOwnedShirtsID.Contains(id));
    }
}
