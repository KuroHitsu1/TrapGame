using UnityEngine;

// Palang yang berputar terus. Tambahkan juga KillZone di objek yang sama
// dan centang Is Trigger pada collider-nya. Tambah Rigidbody (Is Kinematic).
public class SpinningBar : MonoBehaviour
{
    [Tooltip("Kecepatan putar per detik (derajat). Contoh: Y = 90")]
    public Vector3 rotationSpeed = new Vector3(0f, 90f, 0f);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
