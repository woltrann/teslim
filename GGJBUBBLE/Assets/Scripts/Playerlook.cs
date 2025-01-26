using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform PlayerCamera;
    public Vector2 Sensivitities;

    private Vector2 XYRotation;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 MouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };
        
        XYRotation.x -= MouseInput.y * Sensivitities.y;
        XYRotation.y += MouseInput.x * Sensivitities.x;

        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);
        transform.eulerAngles = new Vector3(0f,XYRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x,0f,0f);

    }
}
