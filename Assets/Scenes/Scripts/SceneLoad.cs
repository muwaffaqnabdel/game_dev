using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadSceneBaru(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void KeluarGame()
    {
        // Menutup aplikasi saat game sudah di-build (.exe / .apk)
        Application.Quit();

        // Menghentikan play mode jika dijalankan di dalam Unity Editor (untuk testing)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
