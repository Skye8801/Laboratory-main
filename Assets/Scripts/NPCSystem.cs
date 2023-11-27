using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;

    bool player_detection = false;

    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.E) && !PlayerMove.dialogue)
        {
            PlayerMove.dialogue = true;
            NewDialogue("Hi");
            NewDialogue("It's nice to meet you!");
            canva.transform.GetChild(0).gameObject.SetActive(true);
            Invoke(nameof(SwitchText), 2f);

        }

    }

    void SwitchText()
    {
        canva.transform.GetChild(0).gameObject.SetActive(false);
        canva.transform.GetChild(1).gameObject.SetActive(true);
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, canva.transform);
        template_clone.GetComponent<TextMeshProUGUI>().text = text; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player_detection = true;
        }
        else
        {
            Debug.Log("NPC no dialogue");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
        PlayerMove.dialogue = false;
        for(int I = 0; I < canva.transform.childCount; I++)
        {
            Destroy(canva.transform.GetChild(I).gameObject);
        }
    }
}
