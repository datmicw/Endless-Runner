using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainManager : MonoBehaviour
{
    public GameObject obstaclePrefab;    // Prefab của vật cản
    public int obstacleStartX = 100;     // Vị trí bắt đầu trên trục X
    public Transform obstacles;
    public PlayerMovement movement;
    private float spawnInterval = 1f;
    public int score = 0;
    public Text scoreText;
    public GameObject retryPanel;

    private void Spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            var randomX = Random.Range(-9.5f, 9.5f);

            Instantiate(obstaclePrefab, new Vector3(randomX, 3, obstacleStartX), Quaternion.identity, obstacles);
        }
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    private void IncreaseScore()
    {
        score += 1;
        UpdateScoreText();
    }
    private void Start()
    {
        InvokeRepeating("IncreaseScore", 0.01f, 0.1f);
        InvokeRepeating("Spawn", 1f, spawnInterval);
    }
    public void CancelScoreUpdate()
    {
        CancelInvoke("IncreaseScore");
        CancelInvoke("Spawn");
    }
}