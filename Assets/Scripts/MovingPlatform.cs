using UnityEngine;

// Platform yang bolak-balik. Pemain yang berdiri di atasnya ikut terbawa.
// Persiapan objek:
//  1. Cube dengan Box Collider biasa (lantai)
//  2. Tambah Box Collider kedua, centang Is Trigger, atur Center Y naik dan Size Y lebih tinggi
//     supaya menutupi area sedikit di atas permukaan platform
//  3. Tambah Rigidbody, centang Is Kinematic, matikan Use Gravity
public class MovingPlatform : MonoBehaviour
{
    [Tooltip("Jarak gerak dari posisi awal (x, y, z)")]
    public Vector3 moveOffset = new Vector3(0f, 0f, 6f);

    [Tooltip("Kecepatan. Makin besar makin cepat")]
    public float speed = 0.5f;

    Vector3 startPos;
    CharacterController rider;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        Vector3 newPos = startPos + moveOffset * t;
        Vector3 delta = newPos - transform.position;

        transform.position = newPos;

        // Bawa pemain yang sedang berdiri di atas
        if (rider != null)
        {
            rider.Move(delta);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rider = other.GetComponent<CharacterController>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rider = null;
        }
    }
}
