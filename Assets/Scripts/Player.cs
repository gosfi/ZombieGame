using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 10;



    Vector3 move()
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += move() * Time.deltaTime;
    }
}
