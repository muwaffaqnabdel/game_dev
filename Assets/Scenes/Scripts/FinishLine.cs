using UnityEngine;
using UnityEngine.SceneManagement; // Wajib untuk pindah level

public class FinishLine : MonoBehaviour
{
    // Kamu bisa tentukan minimal koin untuk lulus level
    public int minCoinsNeeded = 4; 

    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah yang nabrak adalah Player (cek root seperti tadi)
        if (other.CompareTag("Player") || (other.transform.root != null && other.transform.root.CompareTag("Player")))
        {
            // Ambil data koin dari script koin kamu tadi
            // Karena kita pakai 'static int coinCount', kita bisa panggil langsung
            // Perhatikan: Pastikan nama kelas script koin kamu adalah 'CoinPickup'
            
            // if (CoinPickup.coinCount >= minCoinsNeeded) // (Opsional: pakai ini kalau mau ada syarat koin)
            // {
                Debug.Log("Finish! Pindah ke Level 2...");
                SceneManager.LoadScene("Level2"); // Nama Scene Level 2 kamu
            // }
        }
    }
}