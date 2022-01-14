using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadPoint : MonoBehaviour
{
    public string pointName;

    // Start is called before the first frame update
    void Start()
    {

        PlayerController player = InstancesManager.singleton.GetPlayerInstance().GetComponent<PlayerController>();

        if (player != null && player.loadPointName == pointName)
        {
            player.transform.position = transform.position;
        }
    }
}
