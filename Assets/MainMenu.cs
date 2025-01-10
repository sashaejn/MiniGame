using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 

    // Fungsi untuk memuat scene berdasarkan index
    public void LoadInGameScene()
    {
        SceneManager.LoadScene("InGame"); // Ganti 1 dengan index scene yang sesuai
    }

     public void ExitGame()
    {
        Application.Quit(); // Keluar dari aplikasi
        Debug.Log("Game exited"); // Debug untuk memastikan fungsi berjalan (hanya terlihat di Editor)
    }
}
