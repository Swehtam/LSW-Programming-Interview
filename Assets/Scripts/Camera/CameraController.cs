using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        if (player is null) player = InstancesManager.singleton.GetPlayerInstance();

        vcam.m_Follow = player.transform;
    }
}
