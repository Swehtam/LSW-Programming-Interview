using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject shopUI;
    
    public void OpenShopUI()
    {
        shopUI.gameObject.SetActive(true);
    }

    public void CloseShopUI()
    {
        shopUI.gameObject.SetActive(false);
    }
}
