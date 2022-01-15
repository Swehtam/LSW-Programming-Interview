using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarmentSkinsDB : MonoBehaviour
{
    public Skins[] skins;

    private Dictionary<int, Skins> skins_dict = new Dictionary<int, Skins>();

    void Awake()
    {
        foreach (Skins s in skins)
        {
            skins_dict.Add(s.skinID, s);
        }
    }

    public Skins GetSkinByID(int id)
    {
        return skins_dict[id];
    }
}

[System.Serializable]
public struct Skins
{
    public int skinID;
    public Sprite icon;
    public string garmentName;
    public Garment garment;
    public int value;
    public Sprite[] idle_sprites;
    public Sprite[] walk_sprites;
}

public enum Garment { Shirt, Pants };
