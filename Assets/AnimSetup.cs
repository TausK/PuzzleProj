using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSetup : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }


}
