using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 moveDir;

    public Animator animator;
    public Animator vfxAnim;
    public AudioManager audioManager;
    public AimAndShoot aimAndShoot;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(h, v).normalized;
        animator.SetBool("isWalking", moveDir.magnitude > 0);
        if (moveDir.magnitude > 0)
        {
            if (!audioManager.sfxSource.isPlaying)
            {
                audioManager.moveAudio();
            }
        }
        else
        {
            audioManager.stopMoveAudio();
        }
        if (Input.GetMouseButtonDown(0))
        {
            switch (aimAndShoot.magicType)
            {
                case 0:
                    audioManager.fireAudio();
                    break;

                case 1:
                    audioManager.earthAudio();
                    break;

                case 2:
                    audioManager.waterAudio();
                    break;

                case 3:
                    audioManager.fireAudio();
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveDir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("LowRangeEnemy"))
        //{
        //    gameObject.GetComponent<PlayerProperties>().TakeDamage(10f);
        //    Debug.Log("Player hit by LowRangeEnemy");
        //}
    }
}
