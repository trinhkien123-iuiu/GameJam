using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationVFXCode : MonoBehaviour
{
    public Animator animator;

    void awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayVFX(bool playVFX)
    {
        animator.SetBool("playVFX", playVFX);
    }
}
