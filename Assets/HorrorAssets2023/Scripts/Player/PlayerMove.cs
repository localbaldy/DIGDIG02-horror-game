using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = walkSpeed;
    public float gravity = -9f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    private const float walkSpeed = 5f; //dela upp speed i tv� olika v�rden s� vi har ett f�r att g� och ett f�r att sprinta
    private const float runSpeed = 10f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; //minus tv� s� den inte registrerar innan vi n�tt marken
        }
        float x = Input.GetAxis("Horizontal"); //G� med WASD
        float z = Input.GetAxis("Vertical"); //G� med WASD
        Vector3 move = transform.right * x + transform.forward * z; //R�r sig i den riktningen som player ocks� tittar i
        controller.Move(move * moveSpeed * Time.deltaTime);
        //Ref till v�r character controller som driver v�r player + l�ter oss r�ra p� oss
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //S� vi kan hoppa
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        { //r�r oss snabbare med shift tangenten

            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
}
