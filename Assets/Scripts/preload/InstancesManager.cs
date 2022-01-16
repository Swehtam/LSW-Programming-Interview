using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Yarn.Unity;

/*
 * Class created based on singleton project pattern.
 * It's intentioned to keep and supply unique class instances that is presente on each scene of the game.
 * Decreasing the number of call of the method "FindObjectOfType".
 * So, if a instance doesn't exist on the singleton, it will search for the unique instance, salve it, and supply to the caller.
 */
public class InstancesManager : MonoBehaviour
{
    public static InstancesManager singleton;
    [SerializeField] private InstantiatePlayer instantiatePlayer;
    [SerializeField] private StoreEvents storeEvents;
    [SerializeField] private PlayerEvents playerEvents;
    [SerializeField] private GarmentSkinsDB garmentSkins;
    [SerializeField] private PlayerGarmentDB playerGarmentDB;
    [SerializeField] private PlayerStatsDB playerStatsDB;
    
    private DialogueRunner dialogueRunner;
    private PlayerClothesController playerClothesController;
    private GameObject player;

    void Awake()
    {
        if (singleton != null)
            Destroy(singleton);
        else
            singleton = this;

        DontDestroyOnLoad(this);
    }

    //Method reponsible for returning the GameObject of the player when it's requested
    //If the GameObject doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per game)
    public GameObject GetPlayerInstance()
    {
        if (player == null)
        {
            var aux = FindObjectOfType<PlayerController>();

            //If aux is null it's beacause it's the first scene to be loaded in the game, so another script will create the player
            if (aux != null)
                player = aux.gameObject;
        }

        return player;
    }

    //Method reponsible for returning the GarmentSkins, from _preload scene, when it's requested
    //If the GarmentSkins doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per game)
    public GarmentSkinsDB GetGarmentSkinsDBInstance()
    {
        if (garmentSkins == null)
            garmentSkins = FindObjectOfType<GarmentSkinsDB>();

        return garmentSkins;
    }

    //Method reponsible for returning the InstantiatePlayer, from _preload scene, when it's requested
    //If the InstantiatePlayer doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per game)
    public InstantiatePlayer GetInstantiatePlayerInstance()
    {
        if (instantiatePlayer == null)
            instantiatePlayer = FindObjectOfType<InstantiatePlayer>();

        return instantiatePlayer;
    }

    //Method reponsible for returning the PlayerGarmentDB, from _preload scene, when it's requested
    //If the PlayerGarmentDB doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per game)
    public PlayerGarmentDB GetPlayerGarmentDBInstance()
    {
        if (playerGarmentDB == null)
            playerGarmentDB = FindObjectOfType<PlayerGarmentDB>();

        return playerGarmentDB;
    }

    //Method reponsible for returning the PlayerClothesController, from player, when it's requested
    //If the PlayerClothesController doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per game)
    public PlayerClothesController GetPlayerClothesControllerInstance()
    {
        if (playerClothesController == null)
            playerClothesController = FindObjectOfType<PlayerClothesController>();

        return playerClothesController;
    }

    //Method reponsible for returning the PlayerStatsDB, from _preload scene, when it's requested
    //If the PlayerStatsDB doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per game)
    public PlayerStatsDB GetPlayerStatsDBInstance()
    {
        if (playerStatsDB == null)
            playerStatsDB = FindObjectOfType<PlayerStatsDB>();

        return playerStatsDB;
    }

    //Method reponsible for returning the StoreEvents, from _preload scene, when it's requested
    //If the StoreEvents doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per game)
    public StoreEvents GetStoreEventsInstance()
    {
        if (storeEvents == null)
            storeEvents = FindObjectOfType<StoreEvents>();

        return storeEvents;
    }

    //Method reponsible for returning the PlayerEvents, from _preload scene, when it's requested
    //If the PlayerEvents doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per game)
    public PlayerEvents GetPlayerEventsInstance()
    {
        if (playerEvents == null)
            playerEvents = FindObjectOfType<PlayerEvents>();

        return playerEvents;
    }

    //Method reponsible for returning the DialogueRunner, from each scene, when it's requested
    //If the DialogueRunner doesn't exist on the single, it will search for it, save and then return to the caller (this happens once per scene)
    public DialogueRunner GetDialogueRunnerInstance()
    {
        if (dialogueRunner == null)
            dialogueRunner = FindObjectOfType<DialogueRunner>();

        return dialogueRunner;
    }
}
