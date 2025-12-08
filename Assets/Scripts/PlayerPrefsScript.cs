using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerPrefsScript : MonoBehaviour
{

    public static int hiScore = 0;
    public static int timesPlayed;
    public static int musicVolume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("hiScore") == true)  //Setting high score
        {
            hiScore = PlayerPrefs.GetInt("hiScore");
        }
        else
        {
            PlayerPrefs.SetInt("hiScore", 10);
        }

        if (PlayerPrefs.HasKey("timesPlayed") == true) //Counting how many times the game has been played
        {
            timesPlayed = PlayerPrefs.GetInt("timesPlayed");
            timesPlayed += 1;
            PlayerPrefs.SetInt("timesPlayed", timesPlayed);
        }
        else
        {
            PlayerPrefs.SetInt("timesPlayed", 1);
        }

        if (PlayerPrefs.HasKey("musicVolume") == true)
        {
            AudioManager.instance.musicVolume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
        }

        if (PlayerPrefs.HasKey("sfxVolume") == true)
        {
            AudioManager.instance.sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("sfxVolume", 0.5f);
        }
    }

    private void OnGUI()
    {
        int timesPlayed = PlayerPrefs.GetInt("timesPlayed");

        string text = "You have played this game " + timesPlayed + " times";

        GUI.contentColor = Color.indianRed;
        GUILayout.BeginArea(new Rect(650f, 550f, 1600f, 1600f));
        GUILayout.Label($"<size=24>{text}</size>");
        GUILayout.EndArea();
    }
}
