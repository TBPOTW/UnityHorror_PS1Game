using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    CharacterController controller;
    public float gravity = -9.8f;
    private Vector3 velocity;

    public Transform groundCheck;
    bool isGrounded;
    public LayerMask groundMask;

    public float groundDistance = 0.5f;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.forward * vertical + transform.right * horizontal;
        moveDir.y -= 9.81f * Time.deltaTime;
        controller.Move(moveDir * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
