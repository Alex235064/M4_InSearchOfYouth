using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diolog : MonoBehaviour
{
    public GameObject interfaceElement;
    public GameObject text;
    public GameObject E;
    public string playerTag = "Player";

    private bool isInRange = false;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (interfaceElement != null)
            {
                interfaceElement.SetActive(true);
                text.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isInRange = true;
        }
        E.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isInRange = false;
            if (interfaceElement != null)
            {
                interfaceElement.SetActive(false);
                text.SetActive(false);
            }
            E.SetActive(false);
        }
    }

}