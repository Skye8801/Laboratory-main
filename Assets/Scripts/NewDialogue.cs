using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewDialogue : MonoBehaviour
{
    int index = 0;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            if(PlayerMove.dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(false);
                index += 1;
                
                if (transform.childCount == index)
                {
                    index = 0;
                    PlayerMove.dialogue = false;
                }
                else
                {
                    transform.GetChild(index).gameObject.SetActive(true);
                }
            }
            else
            {
                transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
            }
        }
    }
}
