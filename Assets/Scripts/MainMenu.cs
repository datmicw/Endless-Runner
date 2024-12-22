using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public MainManager gameManager;
    public GameData gameData;
    public GameObject panelAbout;
    public GameObject panelOption;
    public GameObject retryPanel;
    public Text finalScore;
    public Slider forceSlider;
    public Slider mapSpeedSlider;

    private void Start()
    {
        GameData.Instance.SaveGameData();
        Debug.Log(GameData.Instance.playerName);
        GameData.Instance.LoadGameData();
        forceSlider.value = GameData.Instance.force;
        mapSpeedSlider.value = GameData.Instance.mapSpeed;
        if (retryPanel) retryPanel.SetActive(false);

        if (panelOption) panelOption.SetActive(false);

        if (panelAbout) panelAbout.SetActive(false);
        if (GameData.Instance != null)
        {
            if (forceSlider != null)
            {
                forceSlider.value = GameData.Instance.force;
                forceSlider.onValueChanged.AddListener(UpdateForce);
            }

            if (mapSpeedSlider != null)
            {
                mapSpeedSlider.value = GameData.Instance.mapSpeed;
                mapSpeedSlider.onValueChanged.AddListener(UpdateMapSpeed);
            }
        }
        else
        {
            Debug.LogError("GameData không tồn tại! Kiểm tra xem GameData đã được thêm vào Scene chưa.");

        }
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
        // xem gameManager và finalScore có được gán đúng không
        if (gameManager == null)
        {
            Debug.LogError("gameManager is not assigned!");
            return;
        }

        if (finalScore == null)
        {
            Debug.LogError("finalScore is not assigned!");
            return;
        }

        if (SceneManager.GetActiveScene().name == "Main")
        {
            retryPanel.SetActive(true);
            finalScore.text = "Final Score " + gameManager.score.ToString();
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateForce(float value)
    {
        if (GameData.Instance != null)
        {
            GameData.Instance.force = value;
            Debug.Log("Force được cập nhật trong Menu: " + value);
        }
        else
        {
            Debug.LogError("GameData không tồn tại!");
        }
    }

    public void UpdateMapSpeed(float value)
    {
        if (GameData.Instance != null)
        {
            GameData.Instance.mapSpeed = value;
            Debug.Log("Map Speed được cập nhật trong Menu: " + value);
        }
        else
        {
            Debug.LogError("GameData không tồn tại!");
        }
    }

}