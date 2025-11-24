using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    float xvel, yvel, zvel;
    public Rigidbody rb;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        LevelManager.instance.playerHealth = 100;
        LevelManager.instance.playerRespawnPosition = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            zvel = 5;
            rb.linearVelocity = Vector3.forward * zvel;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zvel = -5;
            rb.linearVelocity = Vector3.forward * zvel;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xvel = 5;
            rb.linearVelocity = Vector3.right * xvel;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            xvel = -5;
            rb.linearVelocity = Vector3.right * xvel;
        }

        LevelManager.instance.HealthCheck();
    }

    private void OnGUI()
    {
        int score = LevelManager.instance.GetHighScore();

        string text = "High score: " + score;

        text += "\nThis is more text";

        GUI.contentColor = Color.wheat;
        GUILayout.BeginArea(new Rect(10f, 10f, 1600f, 1600f));
        GUILayout.Label($"<size=24>{text}</size>");
        GUILayout.EndArea();
    }
}
