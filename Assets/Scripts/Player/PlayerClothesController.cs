using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClothesController : MonoBehaviour
{
    public SpriteRenderer pantsSR;
    public SpriteRenderer shirtSR;

    public Skins shirtSkin;
    public Skins pantsSkin;

    private int pantsID = -1;
    private int shirtID = -1;
    private SpriteRenderer characterSR;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        characterSR = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
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

    public void ChangeCloth(Skins skin, Garment garment)
    {
        switch (garment)
        {
            case Garment.Shirt:
                shirtSkin = skin;
                shirtID = skin.skinID;
                break;

            case Garment.Pants:
                pantsSkin = skin;
                pantsID = skin.skinID;
                break;
        }
    }
}
