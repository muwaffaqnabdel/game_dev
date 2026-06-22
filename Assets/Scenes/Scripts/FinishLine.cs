using UnityEngine;
using UnityEngine.SceneManagement; // Wajib untuk pindah level

public class FinishLine : MonoBehaviour
{
    [Header("Coin Requirements")]
    public int minCoinsNeeded = 4; // Minimal koin untuk lulus level

    [Header("UI Panels")]
    public GameObject successPanel; // Tarik panel "game berhasil diselesaikan" ke sini
    public GameObject failurePanel; // Tarik panel "gagal menyelesaikan" ke sini

    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah yang nabrak adalah Player
        if (other.CompareTag("Player") || (other.transform.root != null && other.transform.root.CompareTag("Player")))
        {
            // Ambil data koin dari script CoinPickup (sekarang sudah public static)
            if (CoinPickup.coinCount >= minCoinsNeeded)
            {
                Debug.Log("Finish! Koin terpenuhi. Memunculkan panel sukses...");
                
                if (successPanel != null)
                {
                    successPanel.SetActive(true);
                }
                
                Time.timeScale = 0f; // Hentikan game sementara agar mobil tidak jalan terus
            }
            else
            {
                Debug.Log("Finish! Tapi koin belum cukup. Memunculkan panel gagal...");
                
                if (failurePanel != null)
                {
                    failurePanel.SetActive(true);
                }
                
                Time.timeScale = 0f; // Hentikan game sementara
            }
        }
    }

    // Fungsi untuk Tombol "Lanjut" (Next Level)
    public void LoadNextLevel(string nextSceneName)
    {
        Time.timeScale = 1f; // Kembalikan waktu game menjadi normal
        SceneManager.LoadScene(nextSceneName);
    }

    // Fungsi untuk Tombol "Ulangi" (Retry Level)
    public void RetryLevel()
    {
        Time.timeScale = 1f; // Kembalikan waktu game menjadi normal
        // Load ulang scene yang aktif saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}