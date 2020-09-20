using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

    private void Start()
    {
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ChangeSkin()
    {
        SceneManager.LoadScene("ChooseSkin");
    }

    public void exit()
    {
        Application.Quit();
    }

}
