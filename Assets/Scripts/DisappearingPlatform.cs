using System.Collections;
using UnityEngine;

// Platform yang hilang beberapa saat setelah diinjak, lalu muncul lagi.
// Persiapan objek: sama seperti MovingPlatform (collider lantai + collider trigger di atasnya).
// Rigidbody tidak wajib.
public class DisappearingPlatform : MonoBehaviour
{
    [Tooltip("Berapa detik setelah diinjak sampai hilang. 0 = langsung runtuh")]
    public float disappearDelay = 0.6f;

    [Tooltip("Berapa detik sampai muncul lagi")]
    public float reappearTime = 3f;

    bool triggered;
    Renderer[] renderers;
    Collider[] colliders;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {
        triggered = true;

        yield return new WaitForSeconds(disappearDelay);
        SetVisible(false);

        yield return new WaitForSeconds(reappearTime);
        SetVisible(true);

        triggered = false;
    }

    void SetVisible(bool on)
    {
        foreach (Renderer r in renderers) r.enabled = on;
        foreach (Collider c in colliders) c.enabled = on;
    }
}
