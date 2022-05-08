using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    CharacterController playerController;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask groundMask;

    bool isGrounded;
    float groundDistance = 0.4f;
    Vector3 velocity;
    private const float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float WalkX = Input.GetAxis("Horizontal")* speed * Time.deltaTime;
        float WalkY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 transformedMovement = (transform.right * speed * WalkX ) + (transform.forward * speed* WalkY);
        playerController.Move(transformedMovement);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //if grounded and moving downward
        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
