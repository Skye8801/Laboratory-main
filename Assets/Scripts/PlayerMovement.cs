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

        // Koden nedan gör så att om man trycker på högra musknappen så kastar den fram en tallrik med korv där jag klickar musen.

        /* if (Input.GetMouseButtonDown(1))
         {
             RaycastHit hit = new RaycastHit();

             Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);

             Vector3 spawnPosition = hit.point + new Vector3(0, 2, 0);

             Transform parent = hit.transform;

             SpawnFoodObject(spawnPosition, Quaternion.identity, parent);
         }*/

    }

    /*public void SpawnFoodObject(Vector3 position, Quaternion rotation, Transform parent = null)
    {
        if(parent != null)
        {
            GameObject newFoodPrefab = Instantiate(FoodPrefab, position, rotation);
            newFoodPrefab.transform.parent = parent;
        }
        else
        {
            Instantiate(FoodPrefab, position, rotation);
        }
    }*/
}