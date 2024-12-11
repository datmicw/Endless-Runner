using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ObstacleMovement : MonoBehaviour
{
    private MainMenu gameManager; // Tham chiếu đến MainMen

    public GameObject retryPanel; // UI Retry
    public float speed = 20f; // Tốc độ di chuyển
    public Vector3 collisionVelocity = new Vector3(25f, 5f, 10f); // Tốc độ khi va chạm

    private void Start()
    {
        // Tìm MainMenu trong scene
        gameManager = FindObjectOfType<MainMenu>();
        if (retryPanel)
        {
            retryPanel.SetActive(false); // Ẩn retry panel khi bắt đầu game
        }
    }

    // Hàm để hiển thị UI Retry
    public void ShowRetryUI()
    {
        retryPanel.SetActive(true); // Hiển thị UI Retry
    }

    // Hàm để chơi lại game khi nhấn nút Retry
    public void RetryGame()
    {
        // Tải lại scene hiện tại (chơi lại game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Xử lý va chạm
    public void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                // Khi va chạm với player, vật cản sẽ bị đẩy lên và quay
                Rigidbody obstacles = GetComponent<Rigidbody>();
                obstacles.velocity = new Vector3(obstacles.velocity.x, collisionVelocity.y, collisionVelocity.z);
                obstacles.angularVelocity = obstacles.velocity * collisionVelocity.x;

                // Hiển thị retryPanel khi va chạm với player
                if (gameManager)
                {
                    StartCoroutine(ShowRetryAfterDelay(1f));
                }

                Debug.Log("Game Over");
                break;

            case "Obstacle":
                // Va chạm với vật cản khác, vật cản sẽ bị đẩy lui
                other.gameObject.GetComponent<Rigidbody>().velocity = collisionVelocity;
                break;

            case "Destroy":
                // Xóa vật cản nếu va chạm với đối tượng có tag "Destroy"
                Destroy(gameObject);
                break;
        }
    }

    // Coroutine để trì hoãn việc hiển thị UI retry sau 3 giây
    private IEnumerator ShowRetryAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Đợi trong khoảng thời gian đã chỉ định
        gameManager.ShowRetryUI(); // Hiển thị UI Retry
    }

    private void Update()
    {
        // Di chuyển vật thể liên tục theo trục Z
        GetComponent<Rigidbody>().AddForce(0f, 0f, -speed);
    }
}
