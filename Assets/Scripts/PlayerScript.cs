using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    float xvel, yvel, zvel;
    public Rigidbody rb;
    public GameObject player;
    public static int score;

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
        ModifyScore();
    }

    private void OnGUI()
    {
        int score = PlayerPrefs.GetInt("hiScore");

        string text = "High score: " + score;

        GUI.contentColor = Color.wheat;
        GUILayout.BeginArea(new Rect(10f, 50f, 1600f, 1600f));
        GUILayout.Label($"<size=24>{text}</size>");
        GUILayout.EndArea();

        string phealth = LevelManager.instance.playerHealth.ToString();
        string pmaxhealth = LevelManager.instance.maxPlayerHealth.ToString();

        GUI.contentColor = Color.lemonChiffon;
        GUILayout.BeginArea(new Rect(50f, 500f, 1600f, 1600f));
        GUILayout.Label($"<size=48>{phealth + " / " + pmaxhealth}</size>");
        GUILayout.EndArea();

        string scoretext = PlayerScript.score.ToString();

        GUI.contentColor = Color.bisque;
        GUILayout.BeginArea(new Rect(1100f, 50f, 1600f, 1600f));
        GUILayout.Label($"<size=36>{scoretext}</size>");
        GUILayout.EndArea();
    }

    static void ModifyScore()
    {
        if(Input.GetKeyDown(KeyCode.Equals))
        {
            score += 10;
            if (score >= PlayerPrefsScript.hiScore)
            {
                PlayerPrefs.SetInt("hiScore", score);
            }
        }

        if(Input.GetKeyDown(KeyCode.Minus))
        {
            score -= 10;
        }
    }
}
