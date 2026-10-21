using UnityEngine;

// Pasang di objek yang membuat pemain mati saat disentuh (Is Trigger dicentang).
// Contoh: lantai tak terlihat di bawah jalur, atau palang berputar.
public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnManager.Instance.Kill();
        }
    }
}
