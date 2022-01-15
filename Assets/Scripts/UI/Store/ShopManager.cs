using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject item;
    public GameObject contentObject;
    public Scrollbar scrollbar;

    private List<ItemStats> itensAvaliable = new List<ItemStats>();
    private GarmentSkinsDB garmentSkinsDB;

    private void Start()
    {
        garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();
        List<int> itensTest = new List<int>
        {
            0,
            1,
            0,
            1,
            0,
            1
        };
        InstantiateItens(itensTest);
    }

    public void InstantiateItens(List<int> itensID)
    {        
        for(int i = 0; i < itensID.Count; i++)
        {
            //Get garment stats from db
            Skins skin = garmentSkinsDB.GetSkinByID(itensID[i]);
            
            //If the GameObjects where instantiated previously then overwrite the values
            if (i < itensAvaliable.Count)
            {
                //Test
                itensAvaliable[i].UpdateItem(skin.icon, skin.garmentName, skin.value, skin.skinID);
            }
            //Else instantiate new itens
            else
            {
                GameObject itemInstantiated = Instantiate(item, contentObject.transform);

                ItemStats iStats = itemInstantiated.GetComponent<ItemStats>();
                iStats.UpdateItem(skin.icon, skin.garmentName, skin.value, skin.skinID);
                itensAvaliable.Add(iStats);
            }
        }

        if(itensAvaliable.Count > itensID.Count)
        {
            for (int i = itensID.Count; i > itensAvaliable.Count; i++)
            {
                itensAvaliable[i].gameObject.SetActive(false);
            }
        }

        scrollbar.value = 0.9999f;
    }
}
