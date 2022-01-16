using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private PlayerEvents playerEvents;
    private WorldInteraction interaction;

    private bool isInteracting;

    private void Start()
    {
        playerEvents = InstancesManager.singleton.GetPlayerEventsInstance();
        playerEvents.OnPlayerSetInteraction += PlayerSetInteraction;
    }

    private void Update()
    {
        if (isInteracting)
            return;

        if (interaction && Input.GetKeyDown(KeyCode.E))
        {
            interaction.DoInteraction();
            isInteracting = true;
            playerEvents.PlayerSetInteraction(true);
        }
    }

    public void SetInteraction(WorldInteraction worldInt)
    {
        interaction = worldInt;
    }

    public void RemoveInteraction(WorldInteraction worldInt)
    {
        if(worldInt == interaction)
        {
            interaction = null;
        }  
    }

    private void PlayerSetInteraction(bool value)
    {
        isInteracting = value;
    }
}
