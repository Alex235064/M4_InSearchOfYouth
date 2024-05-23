using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diolog : MonoBehaviour
{
    public GameObject interfaceElement;
    public string playerTag = "Player";

    private bool isInRange = false;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (interfaceElement != null)
            {
                interfaceElement.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            if (interfaceElement != null)
            {
                interfaceElement.SetActive(false);
            }
        }
    }

}