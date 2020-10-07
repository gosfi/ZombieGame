using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;
using TheControls;

public class PlayerMovementControls : NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private CharacterController controller = null;

    private Vector2 previousInput;

    private Controls controls;
    private Controls Control
    {
        get
        {
            if (controls != null)
            {
                return controls;
            }
            return controls = new Controls();
        }
    }

    public override void OnStartAuthority()
    {
        enabled = true;

        Control.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Control.Player.Move.canceled += ctx => ResetMovement();
    }

    [ClientCallback]

    private void OnEnable()
    {
        Control.Enable();
    }

    [ClientCallback]

    private void OnDisable()
    {
        Control.Disable();
    }

    [ClientCallback]

    private void Update()
    {
        Move();
    }

    [Client]
    private void SetMovement(Vector2 movement)
    {
        previousInput = movement;
    }

    [Client]
    private void ResetMovement()
    {
        previousInput = Vector2.zero;
    }

    [Client]

    private void Move()
    {
        Vector3 right = controller.transform.right;
        Vector3 forward = controller.transform.forward;
        right.y = 0f;
        forward.y = 0f;

        Vector3 movement = right.normalized * previousInput.x + forward.normalized * previousInput.y;

        controller.Move(movement * movementSpeed * Time.deltaTime);
    }


}
