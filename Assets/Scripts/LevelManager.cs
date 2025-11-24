using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int highScore;
    public GameObject player;
    public Vector3 playerRespawnPosition;

    public float playerHealth;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            print("do destroy");
            Destroy(gameObject);
        }
    }

    public void HealthCheck()
    {
        if(playerHealth <= 0)
        {
            playerHealth = 100;
            player.transform.position = playerRespawnPosition;
        }
    }

    public void SetHighScore(int score)
    {
        highScore = score;
    }
    public int GetHighScore()
    {
        return highScore;
    }
}
