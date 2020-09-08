using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public CharacterController controller;

    void Move()
    {
        float posX = Input.GetAxis("Horizontal");
        float posZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * posX + transform.forward * posZ;

        controller.Move(move * speed * Time.deltaTime);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
