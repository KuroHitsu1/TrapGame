using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Timer, hitungan mati, dan layar clear.
// Pasang di GameObject kosong bernama "GameHUD", lalu isi semua kolom di Inspector.
public class GameHUD : MonoBehaviour
{
    [Header("Teks di layar")]
    public TMP_Text timerText;
    public TMP_Text deathText;

    [Header("Layar clear (akan dimatikan otomatis saat mulai)")]
    public GameObject clearPanel;
    public TMP_Text clearText;

    float elapsed;
    bool finished;

    void Start()
    {
        if (clearPanel != null) clearPanel.SetActive(false);
    }

    void Update()
    {
        if (finished) return;

        elapsed += Time.deltaTime;
        int min = (int)(elapsed / 60f);
        int sec = (int)(elapsed % 60f);

        timerText.text = $"{min:00}:{sec:00}";
        deathText.text = "Mati: " + RespawnManager.Instance.deathCount;
    }

    // Dipanggil oleh FinishLine
    public void Finish()
    {
        if (finished) return;
        finished = true;

        clearPanel.SetActive(true);
        clearText.text = $"CLEAR!\nWaktu {timerText.text}\nMati {RespawnManager.Instance.deathCount}x";

        // Munculkan kursor supaya tombol Restart bisa diklik
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Pasang di OnClick tombol Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
