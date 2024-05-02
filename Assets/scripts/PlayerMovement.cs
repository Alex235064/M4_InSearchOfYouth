using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    Y++;
                    break;
                case "down":
                    Y--;
                    break;
                case "left":
                    X--;
                    break;
                case "right":
                    X++;
                    break;
                default:
                    Debug.LogError("Invalid direction.");
                    break;
            }
        }

        public float DistanceTo(Vector2 other)
        {
            float dx = X - other.X;
            float dy = Y - other.Y;
            return Mathf.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Character : MonoBehaviour
    {
        public Vector2 Position { get; private set; }
        public int AttackDamage { get; private set; } = 50;
        public int AttackRadius { get; private set; } = 30;
        public int Health { get; private set; } = 100;

        private void Start()
        {
            Position = new Vector2(transform.position.x, transform.position.y);
        }

        public void Move(string direction)
        {
            // Ensure that the character moves only in one axis at a time
            if (direction == "up" || direction == "down" || direction == "left" || direction == "right")
            {
                Position.Move(direction);
                transform.position = new Vector3(Position.X, Position.Y, transform.position.z);
            }
        }

        public void MeleeAttack(Character[] targets)
        {
            foreach (var target in targets)
            {
                if (Mathf.Abs(target.Position.X - Position.X) <= AttackRadius &&
                    Mathf.Abs(target.Position.Y - Position.Y) <= AttackRadius)
                {
                    target.TakeDamage(AttackDamage);
                }
            }
        }

        private void TakeDamage(int damage)
        {
            Health -= damage;
            Debug.Log($"Character at {Position} took {damage} damage. Health remaining: {Health}");
        }
    }

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
}