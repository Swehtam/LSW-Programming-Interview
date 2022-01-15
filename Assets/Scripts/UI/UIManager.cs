using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject coinsUI;
    
    public void OpenShopUI()
    {
        shopUI.gameObject.SetActive(true);
        coinsUI.gameObject.SetActive(false);
    }

    public void CloseShopUI()
    {
        shopUI.gameObject.SetActive(false);
        coinsUI.gameObject.SetActive(true);
    }
}
