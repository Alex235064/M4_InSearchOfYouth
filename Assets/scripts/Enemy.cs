using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Vector2 Position { get; private set; }
    public int Damage { get; private set; } = 20;
    public float AttackRange { get; private set; } = 1.0f; // Assume 1 unit distance for simplicity
    public Character Player { get; set; }

    private void Start()
    {
        Position = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        float distanceToPlayer = Position.DistanceTo(Player.Position);
        if (distanceToPlayer <= AttackRange)
        {
            // Attack the player
            Debug.Log($"Enemy attacks player at {Player.Position}!");
            Player.TakeDamage(Damage);
        }
        else
        {
            // Move towards the player
            if (Player.Position.X > Position.X)
                Position.Move("right");
            else
                Position.Move("left");

            if (Player.Position.Y > Position.Y)
                Position.Move("up");
            else
                Position.Move("down");

            transform.position = new Vector3(Position.X, Position.Y, transform.position.z);
        }
    }
}