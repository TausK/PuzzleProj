using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float nextLvlDelay = 1.5f;
    public GameObject playerHall;

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(nextLvlDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine("NextLevel");
            SceneManager.LoadScene(2);
        }

        //if (other.tag == "MusicLvl")
        //{
        //    StartCoroutine("NextLevel");
        //    SceneManager.LoadScene(3);
        //}
    }
}
