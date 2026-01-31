using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossAnim : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

  public void AnimIdle()
    {
        animator.SetInteger("isDoing",0);
    }
   public void AnimAttack1()
    {
        animator.SetInteger("isDoing", 2);
    }
    public void AnimAttack2()
    {
        animator.SetInteger("isDoing", 3);
    }
    public void AnimWalk()
    {
        animator.SetInteger("isDoing", 1);
    }
    public void AnimDie()
    {
        animator.SetInteger("isDoing", -1);
    }
}
