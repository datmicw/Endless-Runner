using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float force = 200f;

    private void Start()
    {
        if (GameData.Instance != null)
        {
            force = GameData.Instance.force;
            Debug.Log("Force được gán từ GameData: " + force);
        }
        else
        {
            Debug.LogError("GameData không tồn tại!");
        }
    }

    private void FixedUpdate()
    {
        Rigidbody player = GetComponent<Rigidbody>();
        if (player == null) return;

        // Di chuyển nhân vật theo phím bấm
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.AddForce(force * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddForce(-force * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
    }
}
