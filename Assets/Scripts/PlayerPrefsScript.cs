using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerPrefsScript : MonoBehaviour
{

    public static int hiScore = 0;
    public static int timesPlayed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Before reading the key, check to see if a value has been stored in it.
        if (PlayerPrefs.HasKey("hiScore") == true)
        {
            hiScore = PlayerPrefs.GetInt("hiScore");
        }
        else
        {
            PlayerPrefs.SetInt("hiScore", 10);
        }

        if (PlayerPrefs.HasKey("timesPlayed") == true)
        {
            timesPlayed = PlayerPrefs.GetInt("timesPlayed");
            timesPlayed += 1;
            PlayerPrefs.SetInt("timesPlayed", timesPlayed);
        }
        else
        {
            PlayerPrefs.SetInt("timesPlayed", 1);
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
