using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 1.5f;

    private void LateUpdate()
    {
        if (player != null) // kiem tra player co ton tai khong
        {
            Vector3 desiredPosition = CalculateDesiredPosition(); 
            SmoothMoveToPlayer(desiredPosition); // Di chuyen camera den vi tri mong muon
        }
    }
    private Vector3 CalculateDesiredPosition()
    {
        return player.position + offset; // Tinh toan vi tri
    }

    private void SmoothMoveToPlayer(Vector3 desiredPosition) // Di chuyen camera den vi tri mong muon
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.LookAt(player);
    }
}