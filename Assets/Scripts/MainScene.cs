using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

    public Text highscore;
    private void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore.text = PlayerPrefs.GetInt("highscore").ToString();
        }
        else
            highscore.gameObject.active = false;
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
