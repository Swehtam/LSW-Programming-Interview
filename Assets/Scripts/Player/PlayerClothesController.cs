using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClothesController : MonoBehaviour
{
    public SpriteRenderer pantsSR;
    public SpriteRenderer shirtSR;

    public Skins shirtSkin;
    public Skins pantsSkin;

    private SpriteRenderer characterSR;
    private PlayerController playerController;

    private StoreEvents storeEvents;
    private PlayerGarmentDB playerGarmentDB;

    private void OnEnable()
    {
        if(playerGarmentDB == null)
            playerGarmentDB = InstancesManager.singleton.GetPlayerGarmentDBInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        characterSR = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();

        storeEvents = InstancesManager.singleton.GetStoreEventsInstance();
        storeEvents.OnGarmentEquiped += ChangeGarment;
    }

    private void LateUpdate()
    {
        int spriteNr;

        //TRANSFORMAR EM UM METHOD
        if (playerController.IsWalking())
        {
            string spriteName = characterSR.sprite.name;
            spriteName = spriteName.Replace("base_character_walk_", "");
            spriteNr = int.Parse(spriteName);
        }
        else
        {
            string spriteName = characterSR.sprite.name;
            spriteName = spriteName.Replace("base_character_idle_", "");
            spriteNr = int.Parse(spriteName);
        }

        UpdateShirt(spriteNr);
        UpdatePants(spriteNr);
    }

    private void UpdateShirt(int spriteNr)
    {
        if (playerController.IsWalking())
        {
            shirtSR.sprite = shirtSkin.walk_sprites[spriteNr];
        }
        else
        {
            shirtSR.sprite = shirtSkin.idle_sprites[spriteNr];
        }
    }

    private void UpdatePants(int spriteNr)
    {
        if (playerController.IsWalking())
        {
            pantsSR.sprite = pantsSkin.walk_sprites[spriteNr];
        }
        else
        {
            pantsSR.sprite = pantsSkin.idle_sprites[spriteNr];
        }
    }

    public void ChangeGarment(Skins skin)
    {
        switch (skin.garment)
        {
            case Garment.Shirt:
                shirtSkin = skin;
                playerGarmentDB.SetShirtID(skin.skinID);
                break;

            case Garment.Pants:
                pantsSkin = skin;
                playerGarmentDB.SetPantsID(skin.skinID);
                break;
        }
    }
}
