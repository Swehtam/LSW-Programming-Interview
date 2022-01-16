using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeController : MonoBehaviour
{
    public GameObject shirtsContentObject;
    public GameObject pantsContentObject;
    public Scrollbar scrollbar;

    public Button saveButton;
    
    /// <summary>
    /// List of Shirts
    /// </summary>
    private List<ItemWardrobe> shirtsAvalible = new List<ItemWardrobe>();
    private int shirtIDSelected;
    //private ItemWardrobe shirtItemWardrobeSelected;

    /// <summary>
    /// List of pants
    /// </summary>
    private List<ItemWardrobe> pantsAvalible = new List<ItemWardrobe>();
    private int pantsIDSelected;
    //private ItemWardrobe pantsItemWardrobeSelected;

    private GarmentSkinsDB garmentSkinsDB;
    private PlayerGarmentDB playerGarmentDB;
    private StoreEvents storeEvents;

    private void Awake()
    {
        playerGarmentDB = InstancesManager.singleton.GetPlayerGarmentDBInstance();
        garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();
        storeEvents = InstancesManager.singleton.GetStoreEventsInstance();
    }

    private void OnEnable()
    {
        shirtIDSelected = playerGarmentDB.GetShirtID();
        pantsIDSelected = playerGarmentDB.GetPantsID();

        InstantiateItens();
    }

    // Update is called once per frame
    void Update()
    {
        saveButton.interactable = (shirtIDSelected != playerGarmentDB.GetShirtID() || pantsIDSelected != playerGarmentDB.GetPantsID());
    }

    public void InstantiateItens()
    {
        List<int> shirtsList = playerGarmentDB.GetOwnedShirtsID();
        InstantiateGarment(shirtsList, shirtsAvalible, shirtsContentObject, shirtIDSelected);

        List<int> pantsList = playerGarmentDB.GetOwnedPantsID();
        InstantiateGarment(pantsList, pantsAvalible, pantsContentObject, pantsIDSelected);

        scrollbar.value = 0.9999f;
    }

    public void InstantiateGarment(List<int> garmentList, List<ItemWardrobe> garmentAvaliable, GameObject garmentContentObject, int equipedSkinID)
    {
        for (int i = 0; i < garmentList.Count; i++)
        {
            //Get garment stats from db
            Skins skin = garmentSkinsDB.GetSkinByID(garmentList[i]);

            //If the GameObjects where instantiated previously then overwrite the values
            if (i < garmentAvaliable.Count)
            {
                garmentAvaliable[i].UpdateItem(skin.icon, skin.skinID, this);
            }
            //Else instantiate new itens
            else
            {
                GameObject itemInstantiated = Instantiate(Resources.Load("Prefabs/ItemWardrobe"), garmentContentObject.transform) as GameObject;

                ItemWardrobe iStats = itemInstantiated.GetComponent<ItemWardrobe>();
                iStats.UpdateItem(skin.icon, skin.skinID, this);
                garmentAvaliable.Add(iStats);
            }

            if (equipedSkinID == garmentList[i])
                garmentAvaliable[i].ItemEquiped();
        }

        if (garmentAvaliable.Count > garmentList.Count)
        {
            for (int i = garmentList.Count; i > garmentAvaliable.Count; i++)
            {
                garmentAvaliable[i].gameObject.SetActive(false);
            }
        }
    }

    public void ItemSelected(int id)
    {
        Skins skin = garmentSkinsDB.GetSkinByID(id);

        switch (skin.garment)
        {
            case Garment.Shirt:
                shirtIDSelected = id;
                break;

            case Garment.Pants:
                pantsIDSelected = id;
                break;
        }

        storeEvents.DollGarmentSelected(id);
    }

    public void SaveOutfit()
    {
        Skins shirt = garmentSkinsDB.GetSkinByID(shirtIDSelected);
        storeEvents.GarmentEquiped(shirt);

        Skins pants = garmentSkinsDB.GetSkinByID(pantsIDSelected);
        storeEvents.GarmentEquiped(pants);
    }
}
