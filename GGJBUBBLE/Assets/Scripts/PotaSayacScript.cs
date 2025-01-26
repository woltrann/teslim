using UnityEngine;

public class PotaSayacScript : MonoBehaviour
{
    private PlayerController nesne;
    public int basketSayisi = 10;

    void Start()
    {
        nesne = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        // Çarpýþan nesnenin bir bubble olduðunu kontrol et
        if (other.gameObject.CompareTag("Bubble"))
        {
            // 2 saniye sonra bubble'ý yok et
            Destroy(other.gameObject, 2f);
            basketSayisi--;
            if (basketSayisi == 0)
            {
                nesne.Room1DoorOpen();
            }

        }
    }
}
