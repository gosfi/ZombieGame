using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 10;
    public float mouseSensitivity = 100f;
    public Transform player;
    public float yRotation = 0f;



    Vector3 Move()
    {
        Vector3 direction = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            direction.x += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.x -= speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.z += speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.z -= speed;

        }
        return direction;
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Move() * Time.deltaTime;
        Rotate();
    }
}
