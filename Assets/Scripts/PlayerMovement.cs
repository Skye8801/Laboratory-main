using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    public bool hideCursor = false;
    public bool freezeCursor = true;
    public float speed = 5;
    public float run = 8;
    public float sens = 12;
    public Transform CharacterCamera;
    public GameObject FoodPrefab;

    CharacterController ch;
    Quaternion camquat;

    static public bool dialogue = false;

    private void Start()
    {
        ch = GetComponent<CharacterController>();

        if (hideCursor) Cursor.visible = false;
        if (freezeCursor) Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector3 move = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;
        if (Input.GetKey(KeyCode.LeftShift)) move *= run;
        else move *= speed;
        move -= Vector3.up * 2;
        ch.Move(move * Time.deltaTime);

        float bodyrot = Input.GetAxis("Mouse X") * sens;
        transform.Rotate(0, bodyrot, 0);
        float camrot = -Input.GetAxis("Mouse Y") * sens;

        CharacterCamera.Rotate(camrot, 0, 0);

        //Klick spacebar to generate a copy of food
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(FoodPrefab, transform.position + transform.forward, FoodPrefab.transform.rotation);
        }

    }
}