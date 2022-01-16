using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCShop : WorldInteraction
{
    public List<int> itemOnShop = new List<int>();

    public string talkToNode = "";
    public string talkToExitNode = "";

    private PlayerEvents playerEvents;
    private DialogueRunner runner;

    private void Start()
    {
        playerEvents = InstancesManager.singleton.GetPlayerEventsInstance();
        runner = InstancesManager.singleton.GetDialogueRunnerInstance();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
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

        if(talkToNode != "")
        {
            runner.StartDialogue(talkToNode);
            return;
        }

        playerEvents.PlayerOpenedShop(itemOnShop);
    }

    public void TalkToExitNode()
    {
        if(talkToExitNode != "")
            runner.StartDialogue(talkToExitNode);
    }

    [YarnCommand("openShop")]
    public void OpenShop()
    {
        playerEvents.PlayerOpenedShop(itemOnShop);
    }

    [YarnCommand("stoped_interaction")]
    public void StopedInteraction()
    {
        playerEvents.PlayerSetInteraction(false);
    }
}
