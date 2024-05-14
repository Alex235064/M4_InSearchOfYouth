using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}