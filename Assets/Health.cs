using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [SerializeField] private GameOverHandler gameOverHandler; // Reference ke GameOverHandler
    [SerializeField] private AudioSource damageSoundEffect;   // Tambahkan variabel untuk efek suara damage

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

        // Cari GameOverHandler secara otomatis jika tidak diatur di Inspector
        if (gameOverHandler == null)
        {
            gameOverHandler = FindObjectOfType<GameOverHandler>();
            if (gameOverHandler == null)
            {
                Debug.LogError("GameOverHandler tidak ditemukan di scene. Pastikan GameOverHandler ada di scene.");
            }
        }
    }

    public void TakeDamage(float _damage)
    {
        if (dead) return;

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        // Mainkan efek suara damage
        if (damageSoundEffect != null)
        {
            damageSoundEffect.Play();
        }
        else
        {
            Debug.LogWarning("damageSoundEffect belum diatur di Inspector!");
        }

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;

                // Pastikan gameOverHandler tidak null sebelum dipanggil
                if (gameOverHandler != null)
                {
                    gameOverHandler.ShowGameOver();
                }
                else
                {
                    Debug.LogError("GameOverHandler tidak terhubung. Pastikan referensi telah diatur.");
                }
            }
        }
    }
}
