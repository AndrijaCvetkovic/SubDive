using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseStoryScene : MonoBehaviour {

    public GameData gameData;
    public GameObject containter;
    public GameObject btnPrefab;

	// Use this for initialization
	void Start () {
        InitCategories();
	}

    private void InitCategories()
    {
        foreach(Story s in gameData.stories)
        {
            GameObject g = Instantiate(btnPrefab);
            g.transform.parent = containter.transform;
            g.transform.localScale = new Vector3(1, 1, 1);
            g.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = s.Image;
            g.GetComponent<Button>().onClick.AddListener(() => StartGame(s));
        }
    }

    public void StartGame(Story s)
    {
        Debug.Log(s.name);
        GameManager.instance.choosenStory = s;
        GameManager.instance.choosenGame = Mode.whileNotHitObsticle;
        SceneManager.LoadScene("Gameplay");

    }

}
