using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public Slider nothingness;

    private void Start()
    {
    }

    public void LevelOneLoad()
    {
        SceneManager.LoadScene(1);
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
    public void Nothingness()
    {
        if (nothingness.value == 1)
        {
            CloseGame();
        }
    }
}
