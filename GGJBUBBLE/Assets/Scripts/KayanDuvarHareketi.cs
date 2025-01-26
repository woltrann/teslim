using UnityEngine;

public class KayanDuvarHareketi : MonoBehaviour
{
    public float speed = 2.0f; // Hareket h�z�

    public float minZ = -131.0f;
    public float maxZ = -106.0f;

    void Start()
    {
        // Obje ba�lang��ta belirtilen aral�kta de�ilse, ba�lang�� pozisyonunu ayarlay�n
        transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
    }

    void Update()
    {
        float z = Mathf.PingPong(Time.time * speed, maxZ - minZ) + minZ;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}

