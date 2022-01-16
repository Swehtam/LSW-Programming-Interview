using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSellController : MonoBehaviour
{
    public GameObject contentObject;
    public Scrollbar scrollbar;

    public Button sellButton;

    private List<ItemStats> itensAvaliableToSell = new List<ItemStats>();
    private int skinSelectedID;
    private ItemStats itemStatsSelected;

    private ShopManager shopManager;
    private GarmentSkinsDB garmentSkinsDB;
    private PlayerGarmentDB playerGarmentDB;
    private PlayerStatsDB playerStatsDB;

    private void OnEnable()
    {
        if (playerStatsDB == null)
            playerStatsDB = InstancesManager.singleton.GetPlayerStatsDBInstance();
        
        if(playerGarmentDB == null)
            playerGarmentDB = InstancesManager.singleton.GetPlayerGarmentDBInstance();

        if (garmentSkinsDB == null)
            garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();

        if(shopManager == null)
            shopManager = GetComponentInParent<ShopManager>();

        skinSelectedID = -1;
        itemStatsSelected = null;

        List<int> itensID = playerGarmentDB.GetOwnedNotUsingSkinsID();
        InstantiateItens(itensID);
    }

    // Update is called once per frame
    void Update()
    {
        sellButton.interactable = (skinSelectedID != -1 && itemStatsSelected);
    }

    public void InstantiateItens(List<int> itensID)
    {
        for (int i = 0; i < itensID.Count; i++)
        {
            //Get garment stats from db
            Skins skin = garmentSkinsDB.GetSkinByID(itensID[i]);

            //If the GameObjects where instantiated previously then overwrite the values
            if (i < itensAvaliableToSell.Count)
            {
                itensAvaliableToSell[i].UpdateItem(skin.icon, skin.garmentName, skin.value, skin.skinID, shopManager);
            }
            //Else instantiate new itens
            else
            {
                GameObject itemInstantiated = Instantiate(Resources.Load("Prefabs/Item"), contentObject.transform) as GameObject;

                ItemStats iStats = itemInstantiated.GetComponent<ItemStats>();
                iStats.UpdateItem(skin.icon, skin.garmentName, skin.value, skin.skinID, shopManager);
                itensAvaliableToSell.Add(iStats);
            }
        }

        if (itensAvaliableToSell.Count > itensID.Count)
        {
            for (int i = itensID.Count; i > itensAvaliableToSell.Count; i++)
            {
                itensAvaliableToSell[i].gameObject.SetActive(false);
            }
        }

        scrollbar.value = 0.9999f;
    }

    public void ItemSelected(int id, ItemStats item)
    {
        skinSelectedID = id;
        itemStatsSelected = item;
    }

    /// <summary>
    /// Method called when player press button "sellButton"
    /// </summary>
    public void SellItem()
    {
        Skins skin = garmentSkinsDB.GetSkinByID(skinSelectedID);

        playerStatsDB.GainCoins(skin.value);
        playerGarmentDB.RemoveSkin(skin);
        itensAvaliableToSell.Remove(itemStatsSelected);
        itemStatsSelected.ItemSold();

        skinSelectedID = -1;
        itemStatsSelected = null;
    }
}
