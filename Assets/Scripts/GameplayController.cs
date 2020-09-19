using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    public GameData gameData;
    public GameObject bckImage;
    public GameObject bckPanels;
    public List<GameObject> panels;
    public int points = 0;
    public int pointsToAdd = 1;
    public Text textPoints;
    public bool parachuteActivated = false;
    public Story story;
    public Mission choosenMission;
    public Mode mode;

	// Use this for initialization
	void Start () {

        InitStoryOrMission();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitStoryOrMission()
    {
        if (GameManager.instance.choosenGame == Mode.whileNotHitObsticle)
        {
            story = GameManager.instance.choosenStory;
            mode = story.mode;
            panels = new List<GameObject>();
            foreach (GameObject g in story.panelsPrefabs)
                panels.Add(g);
            bckImage.GetComponent<Image>().sprite = story.Bck;
        }
        else if (GameManager.instance.choosenGame == Mode.saveTheCreatures)
        {
            choosenMission = GameManager.instance.choosenMission;
            mode = choosenMission.mode;
            panels = new List<GameObject>();
            foreach (GameObject g in choosenMission.panelsPrefabs)
                panels.Add(g);
            bckImage.GetComponent<Image>().sprite = choosenMission.Bck;
        }



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

        if(GameManager.instance.choosenGame == Mode.saveTheCreatures && choosenMission.missionCompleted)
        {
            foreach (GameObject p in g.GetComponent<PanelControllerForSaveCreaturesMode>().creaturesToSave)
            {
                Destroy(p);
            }
            g.GetComponent<PanelControllerForSaveCreaturesMode>().creaturesToSave = new List<GameObject>();
        }

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
        if (GameManager.instance.choosenGame == Mode.whileNotHitObsticle)
        {
            SceneManager.LoadScene("ChooseStory");
        }
        else
        {
            SceneManager.LoadScene("ChooseMission");
        }

    } 

}
