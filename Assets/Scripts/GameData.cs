using UnityEngine;
using System.IO;
public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public string playerName;
    public int hightScore;
    public float force = 100f;
    public float mapSpeed = 20f;
    private string filePath;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không hủy game object này khi chuyển scene
        }
        else
        {
            Destroy(gameObject);
        }
        filePath = Path.Combine(Application.persistentDataPath, "gameData-EndlessRunner.json"); // Lấy đường dẫn lưu trữ dữ liệu
    }
    public void SaveGameData()
    {
        string json = JsonUtility.ToJson(this); // Chuyển dữ liệu thành chuỗi json
        File.WriteAllText(filePath, json); // Lưu dữ liệu vào file
        Debug.Log("Game data saved to: " + filePath);
    }
    public void LoadGameData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("Game data loaded.");
        }
    }
}
