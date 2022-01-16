using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreEvents : MonoBehaviour
{
    public delegate void DollGarmentSelectedEventHandler(int skinID);
    public event DollGarmentSelectedEventHandler OnDollGarmentSelected;
    public delegate void GarmentEquipedEventHandler(Skins skin);
    public event GarmentEquipedEventHandler OnGarmentEquiped;

    public void DollGarmentSelected(int skinID)
    {
        OnDollGarmentSelected?.Invoke(skinID);
    }

    public void GarmentEquiped(Skins skin)
    {
        OnGarmentEquiped?.Invoke(skin);
    }
}
