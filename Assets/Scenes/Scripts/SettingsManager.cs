using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Volume Settings")]
    public AudioSource bgmAudioSource;
    public Slider volumeSlider;

    [Header("Brightness Settings")]
    public Image brightnessOverlay; // Gambar hitam full-screen untuk simulasi kecerahan
    public Slider brightnessSlider;

    void Start()
    {
        // --- Setup Volume ---
        if (bgmAudioSource != null && volumeSlider != null)
        {
            // Mengambil volume yang tersimpan (jika belum ada, default 1)
            float savedVolume = PlayerPrefs.GetFloat("VolumeValue", 1f);
            bgmAudioSource.volume = savedVolume;
            volumeSlider.value = savedVolume;

            // Daftarkan event saat slider digeser
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        // --- Setup Brightness ---
        if (brightnessOverlay != null && brightnessSlider != null)
        {
            // Mengambil kecerahan yang tersimpan (jika belum ada, default 1)
            float savedBrightness = PlayerPrefs.GetFloat("BrightnessValue", 1f);
            brightnessSlider.value = savedBrightness;
            SetBrightness(savedBrightness);

            // Daftarkan event saat slider digeser
            brightnessSlider.onValueChanged.AddListener(SetBrightness);
        }
    }

    public void SetVolume(float value)
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.volume = value;
            PlayerPrefs.SetFloat("VolumeValue", value);
        }
    }

    public void SetBrightness(float value)
    {
        if (brightnessOverlay != null)
        {
            // Nilai slider (0 sampai 1). 
            // Jika 1 (Kecerahan Max) -> Alpha gambar hitam = 0 (Transparan penuh)
            // Jika 0 (Kecerahan Min) -> Alpha gambar hitam = 0.85 (Sangat gelap, tapi tidak hitam total)
            float alpha = 1f - value;
            Color tempColor = brightnessOverlay.color;
            tempColor.a = Mathf.Clamp(alpha, 0f, 0.85f);
            brightnessOverlay.color = tempColor;

            PlayerPrefs.SetFloat("BrightnessValue", value);
        }
    }
}
