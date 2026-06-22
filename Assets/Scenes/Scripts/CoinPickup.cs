using UnityEngine;
using TMPro; // Wajib karena kamu pakai TextMeshPro

public class CoinPickup : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Slot UI kamu
    public static int coinCount = 0; // Menggunakan static agar skor terakumulasi antar koin

    private void Start()
    {
        // Menampilkan skor awal saat game dimulai
        coinCount = 0; // Tambahkan ini agar skor reset tiap ganti level
        UpdateCoinUI();
    }

    private void OnTriggerEnter(Collider other)
{
    // GetComponentInParent akan mencari komponen Rigidbody atau Tag ke tingkat paling atas (induk root)
    if (other.CompareTag("Player") || (other.transform.root != null && other.transform.root.CompareTag("Player")))
    {
        coinCount += 1; 
        UpdateCoinUI();
        Destroy(gameObject);
    }
}

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coin: " + coinCount;
        }
    }
}