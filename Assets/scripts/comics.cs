using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comics : MonoBehaviour
{
    public GameObject uiElementToHide1;
    public GameObject uiElementToHide2;
    public GameObject uiElementToHide3;
    // Добавьте сколько угодно переменных для других элементов интерфейса

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (uiElementToHide1 != null)
            {
                uiElementToHide1.SetActive(false);
                Destroy(uiElementToHide1);
            }
            else
            {
                uiElementToHide2.SetActive(false);
                uiElementToHide3.SetActive(false);
            }

            // Дополнительные условия для других элементов интерфейса
        }
    }
}