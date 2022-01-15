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

    private Button itemButton;
    private int skinID;

    private void Start()
    {
        itemButton = GetComponent<Button>();
        itemButton.interactable = true;
        itemNameText.alpha = 1f;
        itemValueText.alpha = 1f;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1f); ;
    }

    public void UpdateItem(Sprite icon, string name, int value, int id)
    {
        itemIcon.sprite = icon;
        itemNameText.text = name;
        itemValueText.text = value.ToString();
        skinID = id;
    }

    public void ItemBought()
    {
        itemButton.interactable = false;
        itemNameText.alpha = 0.5f;
        itemValueText.alpha = 0.5f;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 0.5f);
    }

    public void ItemSelected()
    {
        InstancesManager.singleton.GetStoreEventsInstance().GarmentSelected(skinID);
    }
}
