using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject item;
    public GameObject contentObject;
    public Scrollbar scrollbar;
    public ToggleGroup toggleGroup;

    public Button wearButton;
    public Button buyButton;

    public TMP_Text playerCoinsText;

    private List<ItemStats> itensAvaliable = new List<ItemStats>();

    private int skinSelectedID;
    private ItemStats itemStatsSelected;

    private GarmentSkinsDB garmentSkinsDB;
    private PlayerGarmentDB playerGarmentDB;
    private PlayerStatsDB playerStatsDB;
    private StoreEvents storeEvents;

    private void OnEnable()
    {
        if (playerStatsDB == null)
            playerStatsDB = InstancesManager.singleton.GetPlayerStatsDBInstance();

        playerCoinsText.text = playerStatsDB.GetPlayerTotalCoins().ToString();

        skinSelectedID = -1;
        itemStatsSelected = null;
    }

    private void Start()
    {
        garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();
        playerGarmentDB = InstancesManager.singleton.GetPlayerGarmentDBInstance();
        storeEvents = InstancesManager.singleton.GetStoreEventsInstance();

        List<int> itensTest = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        InstantiateItens(itensTest);
    }

    private void Update()
    {
        bool isInteractable = (skinSelectedID != -1 && itemStatsSelected);
        wearButton.interactable = isInteractable;
        buyButton.interactable = isInteractable;
    }

    public void InstantiateItens(List<int> itensID)
    {        
        for(int i = 0; i < itensID.Count; i++)
        {
            //Get garment stats from db
            Skins skin = garmentSkinsDB.GetSkinByID(itensID[i]);
            
            //If the GameObjects where instantiated previously then overwrite the values
            if (i < itensAvaliable.Count)
            {
                itensAvaliable[i].UpdateItem(skin.icon, skin.garmentName, skin.value, skin.skinID, this, toggleGroup);
            }
            //Else instantiate new itens
            else
            {
                GameObject itemInstantiated = Instantiate(item, contentObject.transform);

                ItemStats iStats = itemInstantiated.GetComponent<ItemStats>();
                iStats.UpdateItem(skin.icon, skin.garmentName, skin.value, skin.skinID, this, toggleGroup);
                itensAvaliable.Add(iStats);
            }

            if (playerGarmentDB.CheckIfOwns(itensID[i]))
                itensAvaliable[i].ItemBought();
        }

        if(itensAvaliable.Count > itensID.Count)
        {
            for (int i = itensID.Count; i > itensAvaliable.Count; i++)
            {
                itensAvaliable[i].gameObject.SetActive(false);
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
    /// Method called when player press button "buyButton"
    /// </summary>
    public void BuyItem()
    {
        Skins skin = garmentSkinsDB.GetSkinByID(skinSelectedID);

        if (playerStatsDB.SpendCoins(skin.value) == false)
            return;

        itemStatsSelected.ItemBought();
        playerGarmentDB.AddNewSkin(skin);
        storeEvents.GarmentBought(skin);
        playerCoinsText.text = playerStatsDB.GetPlayerTotalCoins().ToString();

        skinSelectedID = -1;
        itemStatsSelected = null;
    }

    /// <summary>
    /// Method called when player press button "wearButton"
    /// </summary>
    public void WearItem()
    {
        storeEvents.GarmentSelected(skinSelectedID);
    }
}
