using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {


    public GameObject bckImage;
    public GameObject bckPanels;
    public List<GameObject> panels;
    public int points = 0;
    public int pointsToAdd = 1;
    public Text textPoints;
    public Character charController;

	// Use this for initialization
	void Start () {

        InitStoryOrMission();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitStoryOrMission()
    {

        AddNewPanelAndDeleteFristOne();
        AddNewPanelAndDeleteFristOne();

        StartCoroutine("countPoints");
    }

    public void AddNewPanelAndDeleteFristOne()
    {

        float y = bckPanels.transform.GetChild(bckPanels.transform.childCount - 1).transform.localPosition.y;
        //i ovo se menja kasnije,ovo je test funkcija za sada
        GameObject g = Instantiate(panels[Random.Range(0, (panels.Count - 1))]);
        Debug.Log(Random.Range(0, (panels.Count - 1)));
        g.transform.parent = bckPanels.transform;
        g.transform.localScale = new Vector3(1, 1, 1);
        //Debug.Log(y);
        g.transform.localPosition = new Vector3(0, y - 2724, 0);

        Destroy(bckPanels.transform.GetChild(0).gameObject);
    }

    IEnumerator countPoints()
    {
        while (true)
        {
            points += pointsToAdd;
            yield return new WaitForSeconds(1f);
            textPoints.text = "Points: " + points.ToString();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Main");

    } 

}
