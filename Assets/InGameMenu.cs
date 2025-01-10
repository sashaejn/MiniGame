using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    // Fungsi untuk memuat scene "Home"
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("Home"); // Ganti "Home" dengan nama scene Anda
    }

    public void ExitGame()
    {
        Debug.Log("Game is exiting..."); // Pesan untuk debug, terlihat di Console saat di editor
        Application.Quit(); 
    }
    
}
