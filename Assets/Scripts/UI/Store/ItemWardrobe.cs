using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemWardrobe : MonoBehaviour
{
    public Image itemIcon;

    private Toggle itemToggle;
    private WardrobeController wardrobeController;
    private int skinID;

    private void Awake()
    {
        itemToggle = GetComponent<Toggle>();
    }

    void Start()
    {
        itemToggle.interactable = true;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1f);
    }

    private void OnDisable()
    {
        itemToggle.isOn = false;
    }

    public void UpdateItem(Sprite icon, int id, WardrobeController wardrobe)
    {
        itemIcon.sprite = icon;
        skinID = id;
        wardrobeController = wardrobe;

        itemToggle.group = GetComponentInParent<ToggleGroup>();
    }

    public void ItemToggleSelected(Toggle change)
    {
        if (itemToggle.isOn)
        {
            itemIcon.rectTransform.sizeDelta = new Vector2(40f, 40f);
            wardrobeController.ItemSelected(skinID);
        }
        else
        {
            itemIcon.rectTransform.sizeDelta = new Vector2(44f, 44f);
        }
    }

    public void ItemEquiped()
    {
        itemToggle.isOn = true;
    }
}
