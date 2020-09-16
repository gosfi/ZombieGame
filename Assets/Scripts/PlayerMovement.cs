﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        const float WALK_SPEED = 10f;
        const float RUN_SPEED = 20f;
        private float speed = WALK_SPEED;
        private CharacterController controller;
        private float gravity = -9.81f;
        public Transform groundCheck;
        private float groundDistance = 0.4f;
        public LayerMask groundMask;
        public float mouseSensitivity = 500f;
        private Transform player;
        float xRotation = 0f;
        Vector3 velocity;
        bool isGrounded;
        [SerializeField] Camera camera;

        const float REGEN_TIME = 5f;
        const float DOWN_TIME = 20f;
        public float updateHp = 100f;
        public float maxHp = 100f;
        public bool canRevive = false;
        public bool isDown = false;
        public bool isHit = false;
        public float downTime = DOWN_TIME;
        public float reviveTime = 0f;

        public GameObject reviveZone;
        public GameObject reviveText;
        public GameObject cameraSpectate;
        public GameObject playerDownTime;
        public GameObject playerReviveTime;
        public GameObject playerReviveCircle;

        float regenPoint = 20f;
        bool isDead = false;
        bool startTime = false;
        int receiveDamage = 10;
        float regenTime = REGEN_TIME;


        private void Start()
        {
            //Cursor.lockState = CursorLockMode.Locked;
            player = this.transform;
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            Move();
            RotatePlayer();
            Gravity();
            CheckGround();
            Regen();
            Revive();
        }

        void Move()
        {
            float posX = Input.GetAxis("Horizontal");
            float posZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * posX + transform.forward * posZ;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift) && !isDown)
            {
                speed = RUN_SPEED;
            }
            else
            {
                speed = WALK_SPEED;
            }

            if (isDown)
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

        void RotatePlayer()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
        }

        void Hit(float dmgReceived)
        {
            updateHp -= dmgReceived;
        }

        void Regen()
        {

            if (isHit)
            {
                startTime = true;
                regenTime = REGEN_TIME;
                isHit = false;

            }


            if (updateHp <= 0)
            {
                startTime = false;
                regenTime = REGEN_TIME;
            }


            if (startTime)
            {
                regenTime -= Time.deltaTime;

            }



            if (regenTime <= 0)
            {
                updateHp += regenPoint * Time.deltaTime;

                if (updateHp > maxHp)
                {
                    updateHp = 100f;
                    startTime = false;
                    regenTime = REGEN_TIME;
                }
            }

            if (updateHp <= 0 && !isDead)
            {
                updateHp = 0;
                isDown = true;

            }
        }

        void Down()
        {


            if (isDown)
            {
                reviveZone.SetActive(true);
                playerDownTime.SetActive(true);
                playerReviveTime.SetActive(true);
                playerReviveCircle.SetActive(true);
                downTime -= Time.deltaTime;
                canRevive = true;
            }

            if (downTime <= 0)
            {
                Dead();
            }
        }

        void Revive()
        {
            if (Input.GetKey(KeyCode.F) && canRevive)
            {
                reviveTime += 2 * Time.deltaTime;


            }
            else
            {
                reviveTime -= Time.deltaTime;

            }

            if (reviveTime <= 0)
            {
                reviveTime = 0;
            }

            if (reviveTime >= 10f)
            {
                canRevive = false;
                reviveZone.SetActive(false);
                reviveText.SetActive(false);
                playerDownTime.SetActive(false);
                playerReviveTime.SetActive(false);
                playerReviveCircle.SetActive(false);
                isDown = false;
                reviveTime = 0f;
                updateHp = 50f;
                isHit = true;
                downTime = DOWN_TIME;
            }
        }

        void Dead()
        {
            Destroy(player);
            cameraSpectate.SetActive(true);
        }

    }
}

