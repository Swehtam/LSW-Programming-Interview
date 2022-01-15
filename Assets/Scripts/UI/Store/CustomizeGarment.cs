using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeGarment : MonoBehaviour
{
    public PlayerClothesController playerClothes;
    public PlayerController playerController;

    private GarmentSkinsDB garmentSkinsDB;

    private void Start()
    {
        garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();
    }

    public void PutShirt()
    {
        Skins skin = garmentSkinsDB.GetSkinByID(0);
        playerClothes.ChangeGarment(skin);
    }

    public void PutPants()
    {
        Skins skin = garmentSkinsDB.GetSkinByID(1);
        playerClothes.ChangeGarment(skin);
    }

    public void SetWalking(bool value)
    {
        playerController.SetWalkingValue(value);
    }
    public void SetLookSide(float value)
    {
        playerController.SetLookSide(value);
    }
}
