using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spavner : MonoBehaviour
{
    public GameObject spawnObject; // Объект, который мы будем спавнить при смерти игрока

    
    public void SpawnObjectOnDeath( float boss)
    {
        if (boss == 1)
        {
            Instantiate(spawnObject, transform.position, Quaternion.identity);
        }
         // Спавним объект при смерти игрока
    }
}

