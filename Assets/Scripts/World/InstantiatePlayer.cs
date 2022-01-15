using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    private GameObject player;

    public void CreatePlayerAtWorld()
    {
        player = InstancesManager.singleton.GetPlayerInstance();
        if(player == null)
        {
            player = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;

            //Change Prefab name created to "Player", because it instantiate as "Player(Clone)"
            player.transform.name = "Player";
        }

        if (player != null)
        {
            UpdatePlayerSkin();
            UpdatePlayerStats();
        }
    }

    private void UpdatePlayerSkin()
    {
        PlayerGarmentDB playerGarmentDB = InstancesManager.singleton.GetPlayerGarmentDBInstance();
        PlayerClothesController playerClothes= InstancesManager.singleton.GetPlayerClothesControllerInstance();
        GarmentSkinsDB garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();

        //Set Shirt that the player is using
        playerClothes.ChangeGarment(garmentSkinsDB.GetSkinByID(playerGarmentDB.GetShirtID()));

        //Set Shirt that the player is using
        playerClothes.ChangeGarment(garmentSkinsDB.GetSkinByID(playerGarmentDB.GetPantsID()));
    }

    private void UpdatePlayerStats()
    {
        //Set the position the player is going to spawn
        PlayerStatsDB playerStatsDB = InstancesManager.singleton.GetPlayerStatsDBInstance();
        player.GetComponent<PlayerController>().loadPointName = playerStatsDB.GetPlayerStartPoint();
    }
}
