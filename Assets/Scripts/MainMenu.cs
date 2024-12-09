using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject retryPanel;

    private void Start()
    {
        // Ẩn retryPanel khi game bắt đầu
        if (retryPanel)
        {
            retryPanel.SetActive(false);
        }
    }

    // Khi người chơi nhấn nút Play, tải scene Main
    public void OnPlayerButtonClick()
    {
        SceneManager.LoadScene("Main"); 
    }

    // Khi người chơi nhấn nút Exit, thoát ứng dụng
    public void OnExitButton()
    {
#if UNITY_EDITOR
        // Nếu đang chạy trong Unity Editor, chỉ dừng Play
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit(); 
#endif
    }

    public void ShowRetryUI()
    {
        // hiển thị Retry UI nếu đang ở trong scene game
        if (SceneManager.GetActiveScene().name == "Main") 
        {
            retryPanel.SetActive(true); // Hiển thị UI Retry khi game over
        }
    }

    // Hàm để chơi lại game khi nhấn nút Retry
    public void RetryGame()
    {
        // Tải lại scene hiện tại (chơi lại game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}