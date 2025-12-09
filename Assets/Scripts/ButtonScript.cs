using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour
{
    //public Slider nothingness;

    
    public void LevelOneLoad()
    {
        AudioManager.instance.StopClip("MainMenuMusic");
        SceneManager.LoadScene(1);
        AudioManager.instance.PlayClip("Level1Loop");
        AudioManager.instance.ChangeAudioSourceVolume("Level1Loop", AudioManager.instance.musicVolume);
    }
    public void LevelTwoLoad()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelThreeLoad()
    {
        SceneManager.LoadScene(3);
    }
    public void CloseGame()
    {
        Application.Quit();
    }

    /*
    public void Nothingness()
    {
        if (nothingness.value == 1)
        {
            CloseGame();
        }
    }
    */

    public void ChangeMusicVolume( float vol )
    {
        AudioManager.instance.musicVolume = vol;
    }
}
