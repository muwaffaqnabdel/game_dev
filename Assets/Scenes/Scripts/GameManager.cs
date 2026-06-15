using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 🔥 INI YANG PENTING

    public int coin = 0;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        instance = this; // 🔥 SET INSTANCE
    }

    public void AddCoin()
    {
        coin++;
        coinText.text = "Coin: " + coin;
    }
}