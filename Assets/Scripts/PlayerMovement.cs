using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 200f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Nếu nhấn phím D hoặc phím mũi tên phải
        {
            _rb.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // Thêm lực tác động lên trục X
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Nếu nhấn phím A hoặc phím mũi tên trái
        {
            _rb.AddForce(- speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // Thêm lực tác động lên trục X
        }
        
    }
    private void FixedUpdate()
    {
        Movement();
        
    }
}