using UnityEngine;

// Pasang di Cube trigger (Is Trigger dicentang). Saat disentuh pemain, titik respawn disimpan.
public class Checkpoint : MonoBehaviour
{
    [Tooltip("Tempat pemain muncul. Kosongkan kalau mau pakai posisi checkpoint ini sendiri")]
    public Transform spawnPoint;

    bool activated;

    void OnTriggerEnter(Collider other)
    {
        if (activated || !other.CompareTag("Player")) return;

        activated = true;
        RespawnManager.Instance.SetCheckpoint(spawnPoint != null ? spawnPoint : transform);
    }
}
