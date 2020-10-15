﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

namespace Player
{
    public class PlayerMovement : NetworkBehaviour
    {
        const float WALK_SPEED = 10f;
        const float RUN_SPEED = 20f;
        private float speed = WALK_SPEED;
        private CharacterController controller;
        private float gravity = -9.81f;
        public Transform groundCheck;
        private float groundDistance = 0.4f;
        public LayerMask groundMask;
        public float mouseSensitivity = 100f;
        private Transform player;
        float xRotation = 0f;
        Vector3 velocity;
        bool isGrounded;
        

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
        public bool isDead = false;
        bool startTime = false;
        int receiveDamage = 10;
        float regenTime = REGEN_TIME;
        Renderer rend;


        private void Start()
        {
            rend = GetComponent<Renderer>();
            Cursor.lockState = CursorLockMode.Locked;
            player = this.transform;
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
          
                Gravity();
                CheckGround();
                Regen();
                Down();
                Revive();
        
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

       

        public void Hit(float dmgReceived)
        {
            updateHp -= dmgReceived;
            Debug.Log(updateHp + "HP");
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
            isDead = true;
            rend.enabled = false;
            cameraSpectate.SetActive(true);
        }

        public void Respawn()
        {
            isDead = false;
            rend.enabled = true;
            cameraSpectate.SetActive(false);
            updateHp = maxHp;
        }

    }
}

