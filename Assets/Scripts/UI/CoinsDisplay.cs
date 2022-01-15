using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsDisplay : MonoBehaviour
{
    private TMP_Text playerCoinsText;
    private PlayerStatsDB playerStatsDB;

    // Start is called before the first frame update
    void Start()
    {
        playerCoinsText = GetComponentInChildren<TMP_Text>();
        playerStatsDB = InstancesManager.singleton.GetPlayerStatsDBInstance();
    }

    // Update is called once per frame
    void Update()
    {
        playerCoinsText.text = playerStatsDB.GetPlayerTotalCoins().ToString();
    }
}
