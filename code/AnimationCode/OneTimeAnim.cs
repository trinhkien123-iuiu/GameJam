using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeAnim : MonoBehaviour
{
   public Animator animator;
    void Start()
    {
     animator.SetBool("isPlaying", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
