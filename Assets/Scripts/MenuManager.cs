using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");


    }

    // Update is called once per frame
    void Update()
    {

        AudioManager.instance.ChangeAudioSourceVolume("MainMenuMusic", AudioManager.instance.musicVolume);

        AudioManager.instance.ChangeAudioSourceVolume("ButtonPressWah", AudioManager.instance.sfxVolume);

        PlayerPrefs.SetFloat("musicVolume", AudioManager.instance.musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", AudioManager.instance.sfxVolume);

    }
}
