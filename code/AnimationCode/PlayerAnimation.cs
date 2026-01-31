using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    void awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void SetDying(bool isDying)
    {
        animator.SetBool("isDying", isDying);
    }
    public void setMagic(int i)
    {
        if (i == 0)
        {
            animator.SetBool("asset3", false);
            animator.SetBool("asset2", false);
            animator.SetBool("asset1", false);
            animator.SetBool("asset0", true);
        }
        else if (i == 1)
        {
            animator.SetBool("asset0", false);
            animator.SetBool("asset2", false);
            animator.SetBool("asset3", false);
            animator.SetBool("asset1", true);
            
        }
        else if (i == 2)
        {
            animator.SetBool("asset0", false);
            animator.SetBool("asset2", true);
            animator.SetBool("asset3", false);
            animator.SetBool("asset1", false);
        }
        else if (i == 3)
        {
            animator.SetBool("asset0", false);
            animator.SetBool("asset2", false);
            animator.SetBool("asset1", false);
            animator.SetBool("asset3", true);
        }
    }

}
