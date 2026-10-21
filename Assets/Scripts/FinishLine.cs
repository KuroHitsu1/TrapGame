using UnityEngine;

// Pasang di Cube trigger di ujung jalur (Is Trigger dicentang).
public class FinishLine : MonoBehaviour
{
    public GameHUD hud;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hud.Finish();
        }
    }
}
