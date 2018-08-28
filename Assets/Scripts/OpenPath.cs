using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPath : MonoBehaviour
{
    public GameObject door;
    public float delay = 2.5f;

    IEnumerator Open()
    {
        yield return new WaitForSeconds(delay);
        Destroy(door);
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.name == "Daruma")
        {
            StartCoroutine("Open");
        }
    }
}
