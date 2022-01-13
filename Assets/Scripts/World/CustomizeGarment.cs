using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeGarment : MonoBehaviour
{
    public PlayerClothesController playerClothes;
    public PlayerController playerController;

    private GarmentSkins garmentSkins;

    private void Start()
    {
        garmentSkins = InstancesManager.singleton.GetGarmentSkinsInstance();
    }

    public void PutShirt()
    {
        Skins skin = garmentSkins.GetSkinByID(0);
        playerClothes.ChangeCloth(skin, skin.garment);
    }

    public void PutPants()
    {
        Skins skin = garmentSkins.GetSkinByID(1);
        playerClothes.ChangeCloth(skin, skin.garment);
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
