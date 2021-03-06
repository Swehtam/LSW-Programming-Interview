using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeInteraction : WorldInteraction
{
    private PlayerEvents playerEvents;

    private void Start()
    {
        playerEvents = InstancesManager.singleton.GetPlayerEventsInstance();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerInteractionController>().SetInteraction(this);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerInteractionController>().RemoveInteraction(this);
        }
    }

    public override void DoInteraction()
    {
        base.DoInteraction();

        playerEvents.PlayerOpenedWardrobe();
    }
}
