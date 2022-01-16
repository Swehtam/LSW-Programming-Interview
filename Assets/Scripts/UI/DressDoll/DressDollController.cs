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
    private float directionX = 1f;

    private StoreEvents storeEvents;
    private GarmentSkinsDB garmentSkinsDB;
    private PlayerGarmentDB playerGarmentDB;

    private void Awake()
    {
        playerGarmentDB = InstancesManager.singleton.GetPlayerGarmentDBInstance();
        garmentSkinsDB = InstancesManager.singleton.GetGarmentSkinsDBInstance();
        storeEvents = InstancesManager.singleton.GetStoreEventsInstance();

        storeEvents.OnDollGarmentSelected += ChangeGarment;
    }

    private void OnEnable()
    {
        //Display Dress Doll with the current outfit the player is using
        ChangeGarment(playerGarmentDB.GetPantsID());
        ChangeGarment(playerGarmentDB.GetShirtID());

        isWalking = false;
        directionX = 1f;
    }

    private void Start()
    {
        characterSR = GetComponent<Image>();
        anim = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        storeEvents.OnDollGarmentSelected -= ChangeGarment;
    }

    private void LateUpdate()
    {
        string spriteName = characterSR.sprite.name;
        spriteName = isWalking ? spriteName.Replace("base_character_walk_", "") : spriteName.Replace("base_character_idle_", "");
        int spriteNr = int.Parse(spriteName);

        UpdateShirt(spriteNr);
        UpdatePants(spriteNr);

        anim.SetFloat("LookDirection", directionX);
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
        directionX = value;
        anim.SetFloat("LookDirection", directionX);
    }

    public void SetWalkingValue(bool value)
    {
        isWalking = value;
        anim.SetBool("IsWalking", isWalking);
    }
}
