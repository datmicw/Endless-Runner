using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainManager : MonoBehaviour
{
    public GameObject obstaclePrefab;    // Prefab của vật cản
    public int obstacleStartX = 100;     // Vị trí bắt đầu trên trục X
    public Transform obstacles;          // Transform chứa các vật cản
    public PlayerMovement movement;     // Script PlayerMovement
    private float spawnInterval = 1f; // Khoảng cách giữa các lần spawn
    public int score = 0;         // Biến lưu điểm số
    public TMP_Text  scoreText;        // Text UI hiển thị điểm

    private void Spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            var randomX = Random.Range(-9.5f, 9.5f);

            // Tạo vật cản tại vị trí ngẫu nhiên trên trục X và trục Z
            Instantiate(obstaclePrefab, new Vector3(randomX, 3, obstacleStartX), Quaternion.identity, obstacles);
        }
    }
    public void AddScore(int points)
    {
        score += points;          // Tăng điểm
        UpdateScoreText();        // Cập nhật UI
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    private void IncreaseScore()
    {
        score += 1; // Tăng điểm lên 1
        UpdateScoreText(); // Cập nhật Text UI
    }
    private void Start()
    {
        InvokeRepeating("IncreaseScore", 0.1f, 1f); // Gọi IncreaseScore mỗi 0.1 giây
        // Gọi Spawn mỗi khoảng thời gian được xác định
        InvokeRepeating("Spawn", 1f, spawnInterval);
    }
}