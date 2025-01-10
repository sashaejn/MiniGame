using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public Text Bananatext;
    private Vector3 startPosition; 

    public int currentBananas = 0;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private int jumpCount = 0;
    private bool isGrounded = false;

    [SerializeField] private float fallThreshold = -10f;
    [SerializeField] private float fallDamage = 1f;     
    private Health playerHealth;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;

    private void Start()
{

    
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sprite = GetComponent<SpriteRenderer>();
    playerHealth = GetComponent<Health>();

    startPosition = transform.position; 

    if (rb == null || anim == null || sprite == null || playerHealth == null)
    {
        Debug.LogError("Salah satu atau lebih komponen hilang dari GameObject.");
    }
}


    private void Update()
    {
        Bananatext.text = currentBananas.ToString();

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            
            if (isGrounded || jumpCount < 2)
            {
                Jump();
            }
        }

        CheckForFallDeath();
        UpdateAnimationState();
    }




    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private void CheckForFallDeath()
    {
        if (transform.position.y < fallThreshold)
        {
            playerHealth.TakeDamage(fallDamage); // Kurangi hanya 1 nyawa
            RespawnPlayer(); // Tambahkan fungsi respawn jika diperlukan
        }
    }

    private void RespawnPlayer()
{
    transform.position = startPosition; // Kembalikan pemain ke posisi awal
    rb.velocity = Vector2.zero; // Hentikan kecepatan pemain
}


    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Banana"))
    {
        currentBananas++;
        Destroy(other.gameObject);

       
        if (collectSoundEffect != null)
        {
            collectSoundEffect.Play(); 
        }
        else
        {
            Debug.LogWarning("collectSoundEffect belum diatur di Inspector!");
        }
    }
}


    void Jump()
{
    if (jumpSoundEffect != null)
    {
        jumpSoundEffect.Play(); // Memutar efek suara melompat
    }
    else
    {
        Debug.LogWarning("JumpSoundEffect belum diatur di Inspector!");
    }

    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    jumpCount++;
}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
