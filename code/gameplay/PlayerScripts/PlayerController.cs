using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 moveDir;

    private Animator animator;
    public AudioManager AudioManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AudioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(h, v).normalized;
        animator.SetBool("isWalking", moveDir != Vector2.zero);
        if (moveDir != Vector2.zero)
        {
            if(!AudioManager.sfxSource.isPlaying)
            {
                AudioManager.moveAudio();
            }
        }
        else
        {
            AudioManager.stopMoveAudio();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * speed;
    }
}
