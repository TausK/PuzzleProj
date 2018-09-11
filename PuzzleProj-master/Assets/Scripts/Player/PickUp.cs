using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;
    public bool picked = false;
    float scrW = Screen.width / 16;
    float scrH = Screen.height / 9;

    public bool uiPick = false;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        if (Screen.width / 16 != scrW || Screen.height / 9 != scrH)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;
        }
    }


    void Update()
    {
        //If picked is true then....
        if (picked)
        {
            Debug.Log(picked);
            
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(player);

        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.SetParent(null);
          
        }

    }

}