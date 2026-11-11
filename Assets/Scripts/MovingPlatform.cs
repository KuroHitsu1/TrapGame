using UnityEngine;

// Platform yang bolak-balik. Pemain yang berdiri di atasnya ikut terbawa.
// Persiapan objek: Cube dengan Box Collider biasa (bukan trigger).
// Collider kedua (trigger) dan Rigidbody tidak lagi dibutuhkan, boleh dibiarkan atau dihapus.
public class MovingPlatform : MonoBehaviour
{
    [Tooltip("Jarak gerak dari posisi awal (x, y, z)")]
    public Vector3 moveOffset = new Vector3(0f, 0f, 6f);

    [Tooltip("Kecepatan. Makin besar makin cepat")]
    public float speed = 0.5f;

    [Tooltip("Tinggi area di atas platform yang dihitung sebagai 'berdiri di atas' (meter)")]
    public float detectHeight = 0.6f;

    Vector3 startPos;
    Collider solidCollider;

    void Start()
    {
        startPos = transform.position;

        // Cari collider lantai (yang bukan trigger)
        foreach (Collider c in GetComponents<Collider>())
        {
            if (!c.isTrigger)
            {
                solidCollider = c;
                break;
            }
        }
    }

    void Update()
    {
        CharacterController rider = FindRider();

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

    // Cek langsung apakah ada pemain di atas platform (tidak bergantung pada trigger)
    CharacterController FindRider()
    {
        if (solidCollider == null) return null;

        Bounds b = solidCollider.bounds;
        float halfH = detectHeight * 0.5f;
        Vector3 center = new Vector3(b.center.x, b.max.y + halfH - 0.1f, b.center.z);
        Vector3 halfExtents = new Vector3(b.extents.x, halfH, b.extents.z);

        Collider[] hits = Physics.OverlapBox(center, halfExtents, Quaternion.identity);
        foreach (Collider h in hits)
        {
            if (h.CompareTag("Player"))
            {
                CharacterController cc = h.GetComponent<CharacterController>();
                if (cc != null) return cc;
            }
        }
        return null;
    }
}