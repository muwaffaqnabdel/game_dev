using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("UI Panel Settings")]
    public GameObject settingsPanel;

    // Fungsi untuk membuka panel settings dan menjeda (pause) game
    public void OpenSettingsAndPause()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
            Time.timeScale = 0f; // Menghentikan waktu di dalam game (Freeze)
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("Game Resumed");
        }
    }

    // Memastikan waktu game kembali normal jika berpindah scene
    void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
