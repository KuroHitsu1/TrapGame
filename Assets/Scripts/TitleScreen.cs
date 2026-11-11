using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [Tooltip("Panel judul (seluruh layar)")]
    public GameObject titlePanel;

    bool showing;

    void Start()
    {
        showing = true;
        titlePanel.SetActive(true);

        // Hentikan game (timer dan gerak karakter) sampai Start ditekan
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!showing) return;

        // Kursor harus terlihat supaya tombol Start bisa diklik
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Pasang di OnClick tombol Start
    public void StartGame()
    {
        showing = false;
        titlePanel.SetActive(false);
        Time.timeScale = 1f;

        // Kunci kursor lagi untuk bermain
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}