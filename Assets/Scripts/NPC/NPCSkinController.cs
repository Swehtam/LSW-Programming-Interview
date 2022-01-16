using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSkinController : MonoBehaviour
{
    public SpriteRenderer pantsSR;
    public SpriteRenderer shirtSR;

    public int shirtID;
    public int pantsID;

    private Skins shirtSkin;
    private Skins pantsSkin;

    private SpriteRenderer npcSR;
    private GarmentSkinsDB garmentSkinsDB;

    void Start()
    {
        npcSR = GetComponent<SpriteRenderer>();
        garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();

        shirtSkin = garmentSkinsDB.GetSkinByID(shirtID);
        pantsSkin = garmentSkinsDB.GetSkinByID(pantsID);
    }

    private void LateUpdate()
    {
        int spriteNr;

        string spriteName = npcSR.sprite.name;
        spriteName = spriteName.Replace("base_character_idle_", "");
        spriteNr = int.Parse(spriteName);

        shirtSR.sprite = shirtSkin.idle_sprites[spriteNr];
        pantsSR.sprite = pantsSkin.idle_sprites[spriteNr];
    }
}
