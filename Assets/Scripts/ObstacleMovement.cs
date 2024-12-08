using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 200f; // Toc do di chuyen
    public Vector3 collisionVelocity = new Vector3(25f, 5f, 10f); // Toc do khi va cham

    public void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Rigidbody obstacles = GetComponent<Rigidbody>();
                obstacles.velocity = new Vector3(obstacles.velocity.x, collisionVelocity.y, collisionVelocity.z); // Khi va cham voi player, obstacle se bi day len
                obstacles.angularVelocity = obstacles.velocity * collisionVelocity.x; // Khi va cham voi player, obstacle se bi quay
                Debug.Log("Game Over");
                break;
            case "Obstacle":
                other.gameObject.GetComponent<Rigidbody>().velocity = collisionVelocity; // Khi va cham voi obstacle khac, obstacle khac se bi day lui
                break;
            case "Destroy":
                Destroy(gameObject);
                break;
        }
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(0f, 0f, -speed); // Di chuyen theo truc Z
    }
}
