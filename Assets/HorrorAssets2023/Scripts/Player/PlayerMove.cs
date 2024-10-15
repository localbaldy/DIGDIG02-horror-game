using UnityEngine;
using System.Collections;

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
    private const float walkSpeed = 5f; // Walk speed
    private const float runSpeed = 10f; // Run speed
    public GameObject Player;
    public GameObject Walking;
    public GameObject Running;

    private AudioSource walkingAudio;
    private AudioSource runningAudio;

    void Start()
    {
        walkingAudio = Walking.GetComponent<AudioSource>();
        runningAudio = Running.GetComponent<AudioSource>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Uncomment if jumping logic is needed
            // velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (move.magnitude > 0 && isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                // Running
                moveSpeed = runSpeed;

                if (!runningAudio.isPlaying)
                {
                    runningAudio.Play();  // Start running sound
                }

                walkingAudio.Stop();      // Stop walking sound if playing
            }
            else
            {
                // Walking
                moveSpeed = walkSpeed;

                if (!walkingAudio.isPlaying)
                {
                    walkingAudio.Play();  // Start walking sound
                }

                runningAudio.Stop();      // Stop running sound if playing
            }
        }
        else
        {
            // Stop both sounds when not moving
            walkingAudio.Stop();
            runningAudio.Stop();
        }
    }
}
