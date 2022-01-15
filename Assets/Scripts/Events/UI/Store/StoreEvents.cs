using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreEvents : MonoBehaviour
{
    public delegate void GarmentSelectedEventHandler(int skinID);
    public event GarmentSelectedEventHandler OnGarmentSelected;

    public void GarmentSelected(int skinID)
    {
        OnGarmentSelected?.Invoke(skinID);
    }
}
