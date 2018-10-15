using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkInput : NetworkBehaviour
{
    public movement.PlayerController playerControl;
    public Orbit cam;

    private void Start()
    {
        if (!isLocalPlayer)
        {
           
        }
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            
        }
    }
}
