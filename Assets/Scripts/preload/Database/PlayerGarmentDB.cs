using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void SetShirtID(int shirtID)
    {
        playerShirtID = shirtID;
    }

    public int GetPantsID()
    {
        return playerPantsID;
    }

    public void SetPantsID(int pantsID)
    {
        playerPantsID = pantsID;
    }

    public List<int> GetOwnedShirtsID()
    {
        return playerOwnedShirtsID;
    }

    public List<int> GetOwnedPantsID()
    {
        return playerOwnedPantsID;
    }

    /// <summary>
    /// Return list of skin that the player owns, but is not using at the time.
    /// Method called when they want to sell skins.
    /// </summary>
    /// <returns></returns>
    public List<int> GetOwnedNotUsingSkinsID()
    {
        List<int> aux = playerOwnedShirtsID.Concat(playerOwnedPantsID).ToList();
        aux.Remove(playerShirtID);
        aux.Remove(playerPantsID);
        return aux;
    }

    public void AddNewSkin(Skins skin)
    {
        switch (skin.garment)
        {
            case Garment.Pants:
                playerOwnedPantsID.Add(skin.skinID);
                break;

            case Garment.Shirt:
                playerOwnedShirtsID.Add(skin.skinID);
                break;
        }
    }

    public void RemoveSkin(Skins skin)
    {
        switch (skin.garment)
        {
            case Garment.Pants:
                playerOwnedPantsID.Remove(skin.skinID);
                break;

            case Garment.Shirt:
                playerOwnedShirtsID.Remove(skin.skinID);
                break;
        }
    }

    public bool CheckIfOwns(int id)
    {
        return playerOwnedShirtsID.Contains(id) || playerOwnedPantsID.Contains(id);
    }
}