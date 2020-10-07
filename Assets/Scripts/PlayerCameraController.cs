using Cinemachine;
using Mirror;
using TheControls;
using UnityEngine;


public class PlayerCameraController : NetworkBehaviour
{
    [Header("Camera")]
    [SerializeField] private Vector2 maxFollowOffset = new Vector2(0f, 0f);
    [SerializeField] private Vector2 cameraVelocity = new Vector2(4f, 0.25f);
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

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

    private CinemachineTransposer transposer;

    public override void OnStartAuthority()
    {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        virtualCamera.gameObject.SetActive(true);

        enabled = true;

        Control.Player.Look.performed += ctx => Look(ctx.ReadValue<Vector2>());

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

    private void Look(Vector2 lookAxis)
    {
        float deltaTime = Time.deltaTime;



        transposer.m_FollowOffset.y = Mathf.Clamp(transposer.m_FollowOffset.y - (lookAxis.y * cameraVelocity.y * deltaTime), maxFollowOffset.x, maxFollowOffset.y);

        playerTransform.Rotate(0f, lookAxis.x * cameraVelocity.x * deltaTime, 0f);
    }
}
