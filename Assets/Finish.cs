using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    [SerializeField] private GameObject finishPanel; // Referensi ke FinishPanel

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();

        if (finishPanel != null)
        {
            finishPanel.SetActive(false); // Nonaktifkan FinishPanel di awal permainan
        }
        else
        {
            Debug.LogWarning("FinishPanel belum diatur. Pastikan Anda menghubungkannya di Inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();
            ShowFinishUI();
        }
    }

    private void ShowFinishUI()
    {
        if (finishPanel != null)
        {
            finishPanel.SetActive(true); // Tampilkan panel Finish
            Time.timeScale = 0f; // Pause permainan
        }
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f; // Mengembalikan waktu normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart level
    }

    public void GoHome()
    {
        Time.timeScale = 1f; // Mengembalikan waktu normal
        SceneManager.LoadScene("HomeScene"); // Ganti "HomeScene" dengan nama scene Home Anda
    }
}
