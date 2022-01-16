using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject coinsUI;
    public GameObject wardrobeUI;

    public  ShopManager shopManager;

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

    public void OpenShopUI(List<int> itensToBuy)
    {
        shopUI.gameObject.SetActive(true);
        shopManager.InstantiateBuyShop(itensToBuy);
        coinsUI.gameObject.SetActive(false);
    }

    public void CloseShopUI()
    {
        shopUI.gameObject.SetActive(false);
        coinsUI.gameObject.SetActive(true);

        playerEvents.PlayerSetInteraction(false);
    }

    public void OpenWardrobeUI()
    {
        wardrobeUI.gameObject.SetActive(true);
        coinsUI.gameObject.SetActive(false);
    }

    public void CloseWardrobeUI()
    {
        wardrobeUI.gameObject.SetActive(false);
        coinsUI.gameObject.SetActive(true);

        playerEvents.PlayerSetInteraction(false);
    }
}
