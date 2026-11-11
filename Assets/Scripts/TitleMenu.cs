using UnityEngine;
using UnityEngine.SceneManagement;

// Untuk scene "Title". Pasang di GameObject kosong bernama "TitleMenu".
// Tombol Start memanggil StartGame() untuk membuka scene permainan.
public class TitleMenu : MonoBehaviour
{
    [Tooltip("Nama scene permainan (harus sama persis, dan sudah masuk Build Profiles)")]
    public string gameSceneName = "Course";

    void Start()
    {
        // Kursor harus terlihat di layar judul
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Pasang di OnClick tombol Start
    public void StartGame()
    {
        // Kunci kursor untuk bermain (statusnya terbawa ke scene berikutnya)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(gameSceneName);
    }
}
