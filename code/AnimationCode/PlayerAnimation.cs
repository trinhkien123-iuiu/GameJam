using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Animator animator;

    void awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

}
