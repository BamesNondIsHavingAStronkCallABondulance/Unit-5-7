using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    Rigidbody rb;
    float xvel, yvel, zvel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelManager.instance.playerHealth -= 10;
            print("health = " + LevelManager.instance.playerHealth);
        }
    }
}
