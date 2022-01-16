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
    private bool wereBought = false;

    private void Awake()
    {
        itemToggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        ResetItem();
    }

    private void OnDisable()
    {
        itemToggle.isOn = false;
    }

    public void UpdateItem(Sprite icon, string name, int value, int id, ShopManager shop)
    {
        itemIcon.sprite = icon;
        itemNameText.text = name;
        itemValueText.text = value.ToString();
        skinID = id;
        shopManager = shop;

        itemToggle.group = GetComponentInParent<ToggleGroup>();

        if (wereBought)
        {
            ResetItem();
        }

    }

    public void ItemBought()
    {
        wereBought = true;
        itemToggle.isOn = false;
        itemToggle.interactable = false;
        itemNameText.alpha = 0.5f;
        itemValueText.alpha = 0.5f;
        soldText.alpha = 1f;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 0.5f);
    }

    public void ResetItem()
    {
        itemToggle.isOn = false;
        itemToggle.interactable = true;
        itemNameText.alpha = 1f;
        itemValueText.alpha = 1f;
        soldText.alpha = 0f;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1f);
        wereBought = false;
    }

    public void ItemSold()
    {
        itemToggle.isOn = false;
        Destroy(gameObject);
    }

    public void ItemToogleChanged(Toggle change)
    {
        if (itemToggle.isOn)
        {
            shopManager.ItemSelected(skinID, this);
        }
    }
}
