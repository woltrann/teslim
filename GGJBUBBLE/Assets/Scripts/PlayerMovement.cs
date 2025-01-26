using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSmoothTime;
    public float GravityStrenght;
    public float JumpStrenght;
    public float WalkSpeed;
    public float RunSpeed;

    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;
    private Vector3 CurrentForceVelocity;
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };
        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }
        
        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;
        CurrentMoveVelocity = Vector3.SmoothDamp(CurrentMoveVelocity, MoveVector * CurrentSpeed, ref MoveDampVelocity, MoveSmoothTime);
        Controller.Move(CurrentMoveVelocity*Time.deltaTime);
        Ray GroundCheckRay = new Ray(transform.position,Vector3.down);
        if (Physics.Raycast(GroundCheckRay, 1.1f))
        {
            CurrentForceVelocity.y = -2f;
            if (Input.GetKey(KeyCode.Space))
            {
                CurrentForceVelocity.y = JumpStrenght;
            }

        }
        else 
        { 
            CurrentForceVelocity.y -= GravityStrenght *Time.deltaTime;
        }
        Controller.Move(CurrentForceVelocity*Time.deltaTime);
    }
}
