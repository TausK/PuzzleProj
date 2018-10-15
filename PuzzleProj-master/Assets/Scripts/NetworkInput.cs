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
        //if pplayer is not localplayer then...
        if (!isLocalPlayer)
        {
            //Diactivate camera
            cam.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        //if we are the local player then..
        if (isLocalPlayer)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            cam.Look(mouseX, mouseY);

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            playerControl.PlayerMovement();

        }
    }
}
