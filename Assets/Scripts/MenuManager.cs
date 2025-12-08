using UnityEngine;

public class MenuManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        AudioManager.instance.ChangeAudioSourceVolume("MainMenuMusic", AudioManager.instance.musicVolume);

        AudioManager.instance.ChangeAudioSourceVolume("ButtonPressWah", AudioManager.instance.sfxVolume);

    }
}
