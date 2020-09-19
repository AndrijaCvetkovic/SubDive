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
        SceneManager.LoadScene("ChooseStory");
    }

    public void PlayMissions()
    {
        SceneManager.LoadScene("ChooseMission");
    }

    public void ChangeSkin()
    {
        SceneManager.LoadScene("ChooseSkin");
    }

}
