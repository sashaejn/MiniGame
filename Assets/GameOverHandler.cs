using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI; // Reference ke UI Game Over
    [SerializeField] private AudioSource gameOverSoundEffect; // Tambahkan AudioSource untuk Game Over sound

    private void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); // Nonaktifkan Panel di awal permainan
        }
        else
        {
            Debug.LogError("GameOverUI belum diatur di Inspector!");
        }

        if (gameOverSoundEffect == null)
        {
            Debug.LogWarning("GameOverSoundEffect belum diatur di Inspector!");
        }
    }

    public void ShowGameOver()
    {
        if (gameOverSoundEffect != null)
        {
            gameOverSoundEffect.Play(); // Mainkan suara Game Over
        }
        else
        {
            Debug.LogWarning("GameOverSoundEffect tidak diatur!");
        }

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Tampilkan Panel Game Over
        }
        Time.timeScale = 0f; // Pause permainan
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Mengembalikan waktu normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload level
    }

    public void QuitGame()
    {
        Application.Quit(); // Keluar dari aplikasi
        Debug.Log("Game exited."); // Ini hanya terlihat saat di editor
    }
}
