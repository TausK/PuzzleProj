using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject daruma;
    public float delaySpawn = 0.5f;
    public PickUp pick;


    IEnumerator SpawnTime()
    {
        pick.picked = false;  
        yield return new WaitForSeconds(delaySpawn);
        transform.position = spawnPoint.position;  
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "KillZone")
        {
            StartCoroutine("SpawnTime");
        }
    }

}
