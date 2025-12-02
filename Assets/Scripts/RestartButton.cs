using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public TMP_Text buttonText;

    private void Start()
    {


    }
    public void Restart()
    {
        LevelManager.instance.maxPlayerHealth -= 5;
        LevelManager.instance.playerHealth = LevelManager.instance.maxPlayerHealth;
        LevelManager.instance.player.transform.position = LevelManager.instance.playerRespawnPosition;

        LevelManager.instance.enemy.transform.position = LevelManager.instance.enemyRespawnPosition;
    }
}
