using System.Collections;
using UnityEngine;

// Mengatur titik respawn dan hitungan jumlah mati.
// Pasang di 1 GameObject kosong bernama "RespawnManager".
public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    [Tooltip("Player (PlayerArmature)")]
    public Transform player;

    [Tooltip("Titik awal permainan (GameObject kosong di awal jalur)")]
    public Transform startPoint;

    [Tooltip("Jeda sebelum pemain dipindahkan (detik). Pendek = cepat main lagi")]
    public float respawnDelay = 0.4f;

    public int deathCount = 0;

    Vector3 respawnPosition;
    Quaternion respawnRotation;
    bool isRespawning;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetCheckpoint(startPoint);
    }

    // Dipanggil oleh Checkpoint
    public void SetCheckpoint(Transform point)
    {
        respawnPosition = point.position;
        respawnRotation = point.rotation;
    }

    // Dipanggil oleh KillZone (jatuh, kena jebakan)
    public void Kill()
    {
        if (isRespawning) return;
        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        isRespawning = true;
        deathCount++;

        yield return new WaitForSeconds(respawnDelay);

        // CharacterController harus dimatikan sebentar, kalau tidak pemain tertarik balik
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;
        player.SetPositionAndRotation(respawnPosition, respawnRotation);
        cc.enabled = true;

        isRespawning = false;
    }
}
