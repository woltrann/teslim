using UnityEngine;

public class pickup : MonoBehaviour
{
    bool isHolding = false;
    [SerializeField]
    float throwForce = 600f;
    [SerializeField]

    float distance;

    TempParent tempParent;
    Rigidbody rb;
    Vector3 objectPos;

    private PlayerController sayi;
    [SerializeField] private string ballColor; // Bu topun rengi: "Red" veya "Yellow"
    void Start()
    {
        sayi=GameObject.Find("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        tempParent = TempParent.Instance;
    }

    
    void Update()
    {
        if (isHolding)
            Hold();
    }
    private void OnMouseDown()
    {
        //pickup
        if (tempParent != null)
        {
            isHolding = true;
            rb.useGravity = false;
            rb.detectCollisions = true;
            this.transform.SetParent(tempParent.transform);
        }
        else
        {
            Debug.Log("Sahnede item bulunamadý");
        }
    }
    private void OnMouseUp()
    {
        Drop();
    }

    private void OnMouseExit()
    {
        Drop();
    }
    private void Hold()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        if (Input.GetMouseButton(1))
        {
            rb.AddForce(tempParent.transform.forward*throwForce);
            Drop();
        }
    }
    private void Drop()
    {
        if (isHolding)
        {
            isHolding = false;
            objectPos = this.transform.position;
            this.transform.position = objectPos;
            this.transform.SetParent(null);
            rb.useGravity = true;
            
                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("YellowCauldron") && ballColor == "Yellow")
        {
            sayi.YellowScore();
        }
        else if (other.CompareTag("RedCauldron") && ballColor == "Red")
        {
            sayi.RedScore();
        }
        else if (other.CompareTag("BlueCauldron") && ballColor == "Blue")
        {
            sayi.BlueScore();
        }
        else if (other.CompareTag("GreenCauldron") && ballColor == "Green")
        {
            sayi.GreenScore();
        }
        else
        {
            Debug.Log("Yanlýþ Kazan!");
        }
    }
}
