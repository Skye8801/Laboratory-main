using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI yourText; // Inserts the text object inside unity inspector
    //public GameObject canvas;

    private void Start()
    {
        yourText.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        { // This is what makes the text appear on screen
            yourText.enabled = true;
        }
    }



    void OnCollisionExit(Collision collision)
    {
      if(collision.gameObject.tag == "Player")
        { // This is what makes the text disapears from the screen
            yourText.enabled = false;
        }
    }
}
