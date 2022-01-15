using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreEvents : MonoBehaviour
{
    public delegate void GarmentSelectedEventHandler(int skinID);
    public event GarmentSelectedEventHandler OnGarmentSelected;
    public delegate void GarmentBoughtEventHandler(Skins skin);
    public event GarmentBoughtEventHandler OnGarmentBought;

    public void GarmentSelected(int skinID)
    {
        OnGarmentSelected?.Invoke(skinID);
    }

    public void GarmentBought(Skins skin)
    {
        OnGarmentBought?.Invoke(skin);
    }
}
