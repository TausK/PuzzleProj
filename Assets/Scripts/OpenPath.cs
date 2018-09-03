using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenPath : MonoBehaviour
{
    public Animator anim;
    public GameObject gate;
    public float delay = 0.5f;
   
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Daruma")
        {
            anim.SetBool("isOpen", true);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Daruma")
        {
            anim.SetBool("isOpen", false);
            //Set Animation to move back 
            //Instantiate(door, transform.position, transform.rotation);
        }
    }
}
