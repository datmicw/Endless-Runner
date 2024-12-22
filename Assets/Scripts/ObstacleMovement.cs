using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ObstacleMovement : MonoBehaviour
{
    private MainMenu mainMenu;
    private MainManager mainManager;

    public GameObject retryPanel;
    public float speed = 20f;
    public Vector3 collisionVelocity = new Vector3(25f, 5f, 10f);
    public GameObject textScore;
    public int finalScore;

    private void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        mainManager = FindObjectOfType<MainManager>();

        if (retryPanel)
        {
            retryPanel.SetActive(false);
        }
        if (GameData.Instance != null)
        {
            speed = GameData.Instance.mapSpeed;
            Debug.Log("Map Speed được gán từ GameData: " + speed);
        }
        else
        {
            Debug.LogError("GameData không tồn tại!");
        }
    }

    public void ShowRetryUI()
    {
        retryPanel.SetActive(true);
    }

    public void RetryGame()
    {
        // Tải lại scene hiện tại (chơi lại game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                Rigidbody obstacles = GetComponent<Rigidbody>();
                obstacles.velocity = new Vector3(obstacles.velocity.x, collisionVelocity.y, collisionVelocity.z);
                obstacles.angularVelocity = obstacles.velocity * collisionVelocity.x;

                if (mainMenu)
                {
                    mainManager.CancelScoreUpdate();
                    finalScore = mainManager.score;
                    StartCoroutine(ShowRetryAfterDelay(2f));
                }

                Debug.Log("Game Over");
                break;

            case "Obstacle":
                other.gameObject.GetComponent<Rigidbody>().velocity = collisionVelocity;
                break;

            case "Destroy":
                Destroy(gameObject);
                break;
        }
    }

    private IEnumerator ShowRetryAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        mainMenu.ShowRetryUI();

    }

    private void FixedUpdate()
    {
        // Di chuyển vật thể liên tục theo trục Z
        GetComponent<Rigidbody>().AddForce(0f, 0f, -speed);
    }
}
