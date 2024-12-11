using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelAbout;
    public GameObject panelOption;
    public GameObject retryPanel;

    private void Start()
    {
        if (retryPanel) retryPanel.SetActive(false);
        
        if (panelOption)panelOption.SetActive(false);
        
        if(panelAbout)panelAbout.SetActive(false);
    }
    public void OnOpenAboutButtonClick()
    {
        panelAbout.SetActive(true);
    }
    public void OnCloseAboutButtonClick()
    {
        panelAbout.SetActive(false);
        
    }
    public void OnOpenOptionButtonClick()
    {
        panelOption.SetActive(true);
    }
    public void OnCloseOptionButtonClick()
    {
        panelOption.SetActive(false);
    }
    // Khi người chơi nhấn nút Play, tải scene Main
    public void OnPlayerButtonClick()
    {
        SceneManager.LoadScene("Main"); 
    }
    // Khi người chơi nhấn nút Exit, thoát ứng dụng
    public void OnExitToMenuButton()
    {
        SceneManager.LoadScene("Menu"); 
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
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