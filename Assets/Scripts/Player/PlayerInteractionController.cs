using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerInteractionController : MonoBehaviour
{
    public Animator interactionAnim;

    private PlayerEvents playerEvents;
    private WorldInteraction interaction;
    private DialogueRunner runner;

    private bool isInteracting;

    private void Start()
    {
        playerEvents = InstancesManager.singleton.GetPlayerEventsInstance();
        playerEvents.OnPlayerSetInteraction += PlayerSetInteraction;
        playerEvents.OnPlayerClosedShop += PlayerClosedShop;

        runner = InstancesManager.singleton.GetDialogueRunnerInstance();
    }

    private void Update()
    {
        if(runner == null)
            runner = InstancesManager.singleton.GetDialogueRunnerInstance();

        if (isInteracting || runner.IsDialogueRunning)
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
        interactionAnim.SetBool("isInteracting", true);
    }

    public void RemoveInteraction(WorldInteraction worldInt)
    {
        if(worldInt == interaction)
        {
            interaction = null;
            interactionAnim.SetBool("isInteracting", false);
        }  
    }

    private void PlayerSetInteraction(bool value)
    {
        isInteracting = value;
    }

    private void PlayerClosedShop()
    {
        if(interaction is NPCShop)
        {
            NPCShop npc = interaction as NPCShop;
            npc.TalkToExitNode();
        }
    }
}
