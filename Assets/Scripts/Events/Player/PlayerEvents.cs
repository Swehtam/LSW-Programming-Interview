using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void PlayerSetInteractionEventHandler(bool isInteracting);
    public event PlayerSetInteractionEventHandler OnPlayerSetInteraction;

    public delegate void PlayerOpenedShopEventHandler(List<int> itensToBuy);
    public event PlayerOpenedShopEventHandler OnPlayerOpenedShop;

    public delegate void PlayerOpenedWardrobeEventHandler();
    public event PlayerOpenedWardrobeEventHandler OnPlayerOpenedWardrobe;

    public void PlayerSetInteraction(bool isInteracting)
    {
        OnPlayerSetInteraction?.Invoke(isInteracting);
    }

    public void PlayerOpenedShop(List<int> itensToBuy)
    {
        OnPlayerOpenedShop?.Invoke(itensToBuy);
    }

    public void PlayerOpenedWardrobe()
    {
        OnPlayerOpenedWardrobe?.Invoke();
    }
}
