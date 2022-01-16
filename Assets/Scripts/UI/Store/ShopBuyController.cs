using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyController : MonoBehaviour
{
    public GameObject contentObject;
    public Scrollbar scrollbar;

    public Button wearButton;
    public Button buyButton;

    private List<int> itensToBuyID = new List<int>();
    private List<ItemStats> itensAvaliableToBuy = new List<ItemStats>();
    private int skinSelectedID;
    private ItemStats itemStatsSelected;

    private ShopManager shopManager;
    private GarmentSkinsDB garmentSkinsDB;
    private PlayerGarmentDB playerGarmentDB;
    private PlayerStatsDB playerStatsDB;
    private StoreEvents storeEvents;

    void Awake()
    {
        shopManager = GetComponentInParent<ShopManager>();
        garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();
        playerGarmentDB = InstancesManager.singleton.GetPlayerGarmentDBInstance();
        storeEvents = InstancesManager.singleton.GetStoreEventsInstance();
        playerStatsDB = InstancesManager.singleton.GetPlayerStatsDBInstance();
    }

    private void OnEnable()
    {
        skinSelectedID = -1;
        itemStatsSelected = null;

        if(itensToBuyID.Count > 0)
            InstantiateItens();
    }

    private void Update()
    {
        bool isInteractable = (skinSelectedID != -1 && itemStatsSelected);
        wearButton.interactable = isInteractable;
        buyButton.interactable = isInteractable;
    }

    public void SetAndInstantiateItensToBuy(List<int> itensID)
    {
        itensToBuyID = itensID;
        InstantiateItens();
    }

    public void InstantiateItens()
    {
        for (int i = 0; i < itensToBuyID.Count; i++)
        {
            //Get garment stats from db
            Skins skin = garmentSkinsDB.GetSkinByID(itensToBuyID[i]);

            //If the GameObjects where instantiated previously then overwrite the values
            if (i < itensAvaliableToBuy.Count)
            {
                itensAvaliableToBuy[i].UpdateItem(skin.icon, skin.garmentName, skin.value, skin.skinID, shopManager);
            }
            //Else instantiate new itens
            else
            {
                GameObject itemInstantiated = Instantiate(Resources.Load("Prefabs/Item"), contentObject.transform) as GameObject;

                ItemStats iStats = itemInstantiated.GetComponent<ItemStats>();
                iStats.UpdateItem(skin.icon, skin.garmentName, skin.value, skin.skinID, shopManager);
                itensAvaliableToBuy.Add(iStats);
            }

            if (playerGarmentDB.CheckIfOwns(skin.skinID))
                itensAvaliableToBuy[i].ItemBought();
        }

        if (itensAvaliableToBuy.Count > itensToBuyID.Count)
        {
            for (int i = itensToBuyID.Count; i > itensAvaliableToBuy.Count; i++)
            {
                itensAvaliableToBuy[i].gameObject.SetActive(false);
            }
        }

        scrollbar.value = 1f;
    }

    public void ItemSelected(int id, ItemStats item)
    {
        skinSelectedID = id;
        itemStatsSelected = item;
    }

    /// <summary>
    /// Method called when player press button "buyButton"
    /// </summary>
    public void BuyItem()
    {
        Skins skin = garmentSkinsDB.GetSkinByID(skinSelectedID);

        if (playerStatsDB.SpendCoins(skin.value) == false)
            return;

        playerGarmentDB.AddNewSkin(skin);
        itemStatsSelected.ItemBought();
        storeEvents.GarmentEquiped(skin);

        skinSelectedID = -1;
        itemStatsSelected = null;
    }

    /// <summary>
    /// Method called when player press button "wearButton"
    /// </summary>
    public void WearItem()
    {
        storeEvents.DollGarmentSelected(skinSelectedID);
    }
}
