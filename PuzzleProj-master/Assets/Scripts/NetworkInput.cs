using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkInput : NetworkBehaviour
{
    public PlayerController playerControl;
    public Orbit cam;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            cam.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            
        }
    }
}
