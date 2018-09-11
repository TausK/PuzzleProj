using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLvl : MonoBehaviour
{
    public float delay = 2f;

    IEnumerator WaitBeforeLoad()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Daruma")
        {
            StartCoroutine("WaitBeforeLoad");          
        }
    }

}
