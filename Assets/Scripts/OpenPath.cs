using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenPath : MonoBehaviour
{
    public Animator anim;
    public GameObject gate;
    public float delay = 0.5f;
   // public bool isOpen;
    private void Start()
    {
        anim.enabled = false;
    }
    IEnumerator Open()
    {
        yield return new WaitForSeconds(delay);
        anim.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Daruma")
        {
            StartCoroutine("Open");
        }


    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Daruma")
        {
            //anim.SetBool("IsOpen", false);
            //Set Animation to move back 
            //Instantiate(door, transform.position, transform.rotation);
        }


    }
}
