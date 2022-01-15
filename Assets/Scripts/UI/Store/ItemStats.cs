using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemStats : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemNameText;
    public TMP_Text itemValueText;
    public TMP_Text soldText;

    private Toggle itemToggle;
    private ShopManager shopManager;
    private int skinID;

    private void Start()
    {
        itemToggle = GetComponent<Toggle>();
        itemToggle.interactable = true;
        itemNameText.alpha = 1f;
        itemValueText.alpha = 1f;
        soldText.alpha = 0f;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1f); ;
    }

    public void UpdateItem(Sprite icon, string name, int value, int id, ShopManager shop, ToggleGroup groupA)
    {
        itemIcon.sprite = icon;
        itemNameText.text = name;
        itemValueText.text = value.ToString();
        skinID = id;
        shopManager = shop;
        itemToggle = GetComponent<Toggle>();
        itemToggle.group = GetComponentInParent<ToggleGroup>();
    }

    public void ItemBought()
    {
        itemToggle.isOn = false;
        itemToggle.interactable = false;
        itemNameText.alpha = 0.5f;
        itemValueText.alpha = 0.5f;
        soldText.alpha = 1f;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 0.5f);
    }

    public void ItemToogleChanged(Toggle change)
    {
        if (itemToggle.isOn)
        {
            shopManager.ItemSelected(skinID, this);
        }
    }
}
