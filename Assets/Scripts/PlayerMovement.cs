using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float WALK_SPEED = 10f;
    const float RUN_SPEED = 20f;

    public float speed = WALK_SPEED;
    public CharacterController controller;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public PlayerSettings playerSet;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        Move();
        Speed();
        Gravity();
        CheckGround();
    }

    void Move()
    {
        float posX = Input.GetAxis("Horizontal");
        float posZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * posX + transform.forward * posZ;

        controller.Move(move * speed * Time.deltaTime);
    }

    void Speed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !playerSet.isDown)
        {
            speed = RUN_SPEED;
        }
        else
        {
            speed = WALK_SPEED;
        }

        if (playerSet.isDown)
        {
            speed /= WALK_SPEED;
        }

    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}
