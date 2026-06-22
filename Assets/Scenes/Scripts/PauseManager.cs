using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("UI Panel Settings")]
    public GameObject settingsPanel;

    private bool isPaused = false;

    // Fungsi untuk membuka panel settings dan menjeda (pause) game
    public void OpenSettingsAndPause()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
            Time.timeScale = 0f; // Menghentikan waktu di dalam game (Freeze)
            isPaused = true;
            Debug.Log("Game Paused");
        }
    }

    // Fungsi untuk menutup panel settings dan melanjutkan (resume) game
    public void CloseSettingsAndResume()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
            Time.timeScale = 1f; // Mengembalikan waktu game menjadi berjalan normal
            isPaused = false;
            Debug.Log("Game Resumed");
        }
    }

    // (Opsional) Mengizinkan player menekan tombol ESCAPE untuk buka/tutup setting
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                CloseSettingsAndResume();
            }
            else
            {
                // Pastikan panel settings tidak sedang aktif sebelum di-pause
                OpenSettingsAndPause();
            }
        }
    }

    // Memastikan waktu game kembali normal jika berpindah scene
    void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
