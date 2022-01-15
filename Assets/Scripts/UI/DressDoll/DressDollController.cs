using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressDollController : MonoBehaviour
{
    public Image pantsSR;
    public Image shirtSR;

    public Skins shirtSkin;
    public Skins pantsSkin;

    private Image characterSR;
    private Animator anim;
    private bool isWalking = false;

    private StoreEvents storeEvents;
    private GarmentSkinsDB garmentSkinsDB;
    private PlayerGarmentDB playerGarmentDB;

    private void Start()
    {
        characterSR = GetComponent<Image>();

        storeEvents = InstancesManager.singleton.GetStoreEventsInstance();
        storeEvents.OnGarmentSelected += ChangeGarment;
    }

    private void OnEnable()
    {
        if(playerGarmentDB == null)
            playerGarmentDB = InstancesManager.singleton.GetPlayerGarmentDBInstance();

        if(garmentSkinsDB == null)
            garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();

        //Display Dress Doll with the current outfit the player is using
        ChangeGarment(playerGarmentDB.GetPantsID());
        ChangeGarment(playerGarmentDB.GetShirtID());

        isWalking = false;

        if(anim == null)
            anim = GetComponent<Animator>();

        anim.SetBool("IsWalking", isWalking);
        anim.SetFloat("LookDirection", 1f);
    }

    private void OnDestroy()
    {
        storeEvents.OnGarmentSelected -= ChangeGarment;
    }

    private void LateUpdate()
    {
        string spriteName = characterSR.sprite.name;
        spriteName = isWalking ? spriteName.Replace("base_character_walk_", "") : spriteName.Replace("base_character_idle_", "");
        int spriteNr = int.Parse(spriteName);

        UpdateShirt(spriteNr);
        UpdatePants(spriteNr);
    }

    private void UpdateShirt(int spriteNr)
    {
        shirtSR.sprite = isWalking ? shirtSkin.walk_sprites[spriteNr] : shirtSkin.idle_sprites[spriteNr];
    }

    private void UpdatePants(int spriteNr)
    {
        pantsSR.sprite = isWalking ? pantsSkin.walk_sprites[spriteNr] : pantsSkin.idle_sprites[spriteNr];
    }

    public void ChangeGarment(int skinID)
    {
        Skins skin = garmentSkinsDB.GetSkinByID(skinID);

        switch (skin.garment)
        {
            case Garment.Shirt:
                shirtSkin = skin;
                break;

            case Garment.Pants:
                pantsSkin = skin;
                break;
        }
    }

    public void LookDirection(float value)
    {
        anim.SetFloat("LookDirection", value);
    }

    public void SetWalkingValue(bool value)
    {
        isWalking = value;
        anim.SetBool("IsWalking", isWalking);
    }
}
