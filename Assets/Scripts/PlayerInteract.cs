using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 5f);

            if (hit)
            {
                Interactable interactable;

                hitInfo.transform.TryGetComponent<Interactable>(out interactable);

                if(interactable != null)
                {
                    interactable.OnInteraction();
                }
                else
                {
                    Debug.Log("Not Interactable");
                }
            }
        }
    }
}
