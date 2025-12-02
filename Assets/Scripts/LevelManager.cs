using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject player;
    public GameObject enemy;
    public Vector3 playerRespawnPosition;
    public Vector3 enemyRespawnPosition;
    public float maxPlayerHealth = 100;
    public TMP_Text healthText;

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
            maxPlayerHealth -= 10;
            playerHealth = maxPlayerHealth;
            player.transform.position = playerRespawnPosition;
        }
    }

    public void ReturnToMenu()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DisplayHealth()
    {
        float health = playerHealth;
        float maxHealth = maxPlayerHealth;

        healthText.text = health.ToString() + " / " + maxHealth.ToString();

    }


}
