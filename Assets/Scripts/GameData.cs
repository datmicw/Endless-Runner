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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        filePath = Path.Combine(Application.persistentDataPath, "gameData-EndlessRunner.json");
    }
    public void SaveGameData()
    {
        string json = JsonUtility.ToJson(this); // chuyển thành chuổi JSON để lưu data game in local server
        File.WriteAllText(filePath, json); // Lưu vào file
        Debug.Log("Game data saved to: " + filePath); //Debug.Log(
    }
    public void LoadGameData()
    {
        if(File.Exists(filePath)){
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this); 
            Debug.Log("Game data loaded.");
        }
    }
}
