using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    float xvel, yvel, zvel;
    public Rigidbody rb;
    public GameObject player;
    public static int score;
    public TMP_Text scoreText;

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
        xvel = 0;
        zvel = 0;

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
        LevelManager.instance.ReturnToMenu();
        LevelManager.instance.DisplayHealth();
        ModifyScore();
        DisplayScore();
    }

    private void OnGUI()
    {
        int score = PlayerPrefs.GetInt("hiScore");

        string text = "High score: " + score;

        text += "\nThis is more text";

        GUI.contentColor = Color.wheat;
        GUILayout.BeginArea(new Rect(10f, 50f, 1600f, 1600f));
        GUILayout.Label($"<size=24>{text}</size>");
        GUILayout.EndArea();
    }

    void ModifyScore()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            score -= 10;
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            score += 10;
        }

        if (score >= PlayerPrefsScript.hiScore)
        {
            PlayerPrefs.SetInt("hiScore", score);
        }
    }

    public void DisplayScore()
    {
        float health = score;

        scoreText.text = health.ToString();

    }
}
