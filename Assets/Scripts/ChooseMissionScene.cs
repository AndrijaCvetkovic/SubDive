using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseMissionScene : MonoBehaviour
{

    public GameData gameData;
    public GameObject containter;
    public GameObject btnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InitMissions();
    }

    private void InitMissions()
    {
        foreach (Mission m in gameData.missions)
        {
            GameObject g = Instantiate(btnPrefab);
            g.transform.parent = containter.transform;
            g.transform.localScale = new Vector3(1, 1, 1);
            g.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = m.Image;
            g.GetComponent<Button>().onClick.AddListener(() => StartGame(m));
        }
    }

    public void StartGame(Mission m)
    {
        Debug.Log(m.name);
        GameManager.instance.choosenMission = m;
        GameManager.instance.choosenGame = Mode.saveTheCreatures;
        SceneManager.LoadScene("Gameplay");

    }

}
