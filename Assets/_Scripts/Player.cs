﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public PhotonView photonView;
    public Rigidbody rb;
    public GameObject PlayerCamera;
    public Text PlayerNameText;
    CharacterController controller;
    Vector3 moveDir = Vector3.zero;
    float gravity = 8;
    float speed = 4f;
    public Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        if (photonView.IsMine)
        {
            PlayerCamera.SetActive(true);
            controller = GetComponent<CharacterController>();

        }
    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            CheckInput();
        }
    }
    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            moveDir = new Vector3(0, 0, 1);
            moveDir *= speed;
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {

            moveDir = new Vector3(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

            moveDir = new Vector3(0, 0, -1);
            moveDir *= speed;
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            moveDir = new Vector3(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            moveDir = new Vector3(1, 0, 0);
            moveDir *= speed;
            transform.eulerAngles = new Vector3(0, 90, 0);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {

            moveDir = new Vector3(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            moveDir = new Vector3(-1, 0, 0);
            moveDir *= speed;
            transform.eulerAngles = new Vector3(0, 270, 0);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {


            moveDir = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.SetInteger("dance", 1);

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            anim.SetInteger("dance", 2);

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            anim.SetInteger("dance", 3);

        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            anim.SetInteger("dance", 4);

        }
        if (Input.GetKeyUp(KeyCode.Alpha1)||Input.GetKeyUp(KeyCode.Alpha2)||Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Alpha4))
        {
            anim.SetInteger("dance", 0);

        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

    }
}
