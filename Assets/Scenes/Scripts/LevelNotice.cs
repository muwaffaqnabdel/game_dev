using UnityEngine;

public class LevelNotice : MonoBehaviour
{
    // Waktu dalam detik sebelum teks menghilang
    public float displayDuration = 3f; 

    void Start()
    {
        // Menjalankan perintah nonaktifkan objek setelah waktu tertentu
        Invoke("HideNotice", displayDuration);
    }

    void HideNotice()
    {
        // Menghilangkan teks dari layar
        gameObject.SetActive(false);
    }
}