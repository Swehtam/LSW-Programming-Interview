using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class UIManager : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject coinsUI;
    public GameObject wardrobeUI;

    public  ShopManager shopManager;

    private bool isPlayerShopping;
    private bool isPlayerDressing;

    private PlayerEvents playerEvents;

    private void Start()
    {
        wardrobeUI.gameObject.SetActive(false);
        shopUI.gameObject.SetActive(false);

        playerEvents = InstancesManager.singleton.GetPlayerEventsInstance();
        playerEvents.OnPlayerOpenedShop += OpenShopUI;
        playerEvents.OnPlayerOpenedWardrobe += OpenWardrobeUI;
    }

    private void OnDestroy()
    {
        playerEvents.OnPlayerOpenedShop -= OpenShopUI;
        playerEvents.OnPlayerOpenedWardrobe -= OpenWardrobeUI;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPlayerShopping)
                CloseShopUI();

            if (isPlayerDressing)
                CloseWardrobeUI();
        }

    }

    public void OpenShopUI(List<int> itensToBuy)
    {
        isPlayerShopping = true;

        shopUI.SetActive(true);
        coinsUI.SetActive(false);

        shopManager.InstantiateBuyShop(itensToBuy);
    }

    public void CloseShopUI()
    {
        isPlayerShopping = false;

        shopUI.SetActive(false);
        coinsUI.SetActive(true);

        playerEvents.PlayerSetInteraction(false);
        playerEvents.PlayerClosedShop();
    }

    public void OpenWardrobeUI()
    {
        isPlayerDressing = true;

        wardrobeUI.SetActive(true);
        coinsUI.SetActive(false);
    }

    public void CloseWardrobeUI()
    {
        isPlayerDressing = false;

        wardrobeUI.SetActive(false);
        coinsUI.SetActive(true);

        playerEvents.PlayerSetInteraction(false);
    }
}
