using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public TMP_Text buttonText;

    public GameObject player;

    private void Start()
    {


    }
    public void Restart()
    {
        LevelManager.instance.playerHealth = 3;
        player.transform.position = LevelManager.instance.playerRespawnPosition;


    }
}
