using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    float xvel, yvel, zvel;
    public Transform player;
    public float trackDistance = 40;
    public float speed = 2;
    void Start()
    {
        LevelManager.instance.enemyRespawnPosition = LevelManager.instance.enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelManager.instance.playerHealth -= 10;
            print("health = " + LevelManager.instance.playerHealth);
        }
    }

    private void FollowPlayer()
    {
        transform.LookAt(player);
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance <= trackDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
