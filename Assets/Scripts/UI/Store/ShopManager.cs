using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TMP_Text playerCoinsText;

    public GameObject BuyUI;
    public GameObject SellUI;

    public ShopBuyController shopBuyController;
    public ShopSellController shopSellController;

    private bool isBuyShopOpen;
    private PlayerStatsDB playerStatsDB;

    private void Start()
    {
        playerStatsDB = InstancesManager.singleton.GetPlayerStatsDBInstance();

        isBuyShopOpen = true;
        BuyUI.SetActive(isBuyShopOpen);
        SellUI.SetActive(!isBuyShopOpen);
    }

    private void Update()
    {
        playerCoinsText.text = playerStatsDB.GetPlayerTotalCoins().ToString();
    }

    public void ItemToogleChanged(bool isBuyToggle)
    {
        BuyUI.SetActive(isBuyToggle);
        SellUI.SetActive(!isBuyToggle);
        isBuyShopOpen = isBuyToggle;
    }

    public void ItemSelected(int id, ItemStats item)
    {
        if (isBuyShopOpen)
        {
            shopBuyController.ItemSelected(id, item);
        }
        else
        {
            shopSellController.ItemSelected(id, item);
        }
    }

    public void InstantiateBuyShop(List<int> itensToBuy)
    {
        shopBuyController.SetAndInstantiateItensToBuy(itensToBuy);
    }
}
