using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public GameplayController gc;
    public bool moving = false;
    public Rigidbody2D charRigidbody;
    public float directionX;
    private float ScreenWidth;
    public float moveSpeed = 1;
    public bool boosted = false;
    public bool shield = false;
    bool parachuteReady = true;
    public Image parachuteImageIcon;

    // Use this for initialization
    void Start () {
        charRigidbody = GetComponent<Rigidbody2D>();
        ScreenWidth = Screen.width;
        //Input.multiTouchEnabled = false;
    }

    private void Update()
    {

        if (Input.touchCount == 1)
        {
            
            if (Input.GetTouch(0).position.x > ScreenWidth / 2)
            {
                //move right
                directionX = 1f;
            }
            if (Input.GetTouch(0).position.x < ScreenWidth / 2)
            {
                //move left
                directionX = -1f;
            }

        }
        else if (Input.touchCount > 1)
        {
            
            if (Input.GetTouch(Input.touchCount - 1).position.x > ScreenWidth / 2)
            {
                //move right
                directionX = 1f;
            }
            if (Input.GetTouch(Input.touchCount - 1).position.x < ScreenWidth / 2)
            {
                //move left
                directionX = -1f;
            }
        }
        else
            directionX = 0;

        charRigidbody.velocity = new Vector2(directionX * moveSpeed, charRigidbody.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Border")
        {
            if (gc.mode == Mode.saveTheCreatures)
            {
                if (collision.gameObject.transform.parent.GetComponent<PanelControllerForSaveCreaturesMode>().creaturesToSave.Count == 0)
                {
                    Debug.Log("A");
                    gc.choosenMission.numberOfSavedCreatures += 1;
                    if (gc.choosenMission.numberOfSavedCreatures >= gc.choosenMission.numberOfCreaturesNeedToBeSaved)
                    {
                        Debug.Log("WINED MISSION");
                        //PlayerPrefs.SetInt("MissionNo",)
                        gc.choosenMission.missionCompleted = true;
                    }
                    gc.AddNewPanelAndDeleteFristOne();
                }
                else
                {
                    Debug.Log("LOSE");
                }
            }
            else if (gc.mode == Mode.whileNotHitObsticle)
            {
                Debug.Log("A");
                gc.AddNewPanelAndDeleteFristOne();
            }
            else if (gc.mode == Mode.landWithParachute)
            {
                Debug.Log("A");
                gc.AddNewPanelAndDeleteFristOne();
            }
        }
        else if (collision.gameObject.tag == "ExtraPoints")
        {
            gc.points += 10;
            gc.textPoints.text = "Points: " + gc.points.ToString();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "Boost")
        {
            Destroy(collision.gameObject);
            startBoost();
        }
        else if (collision.gameObject.name == "Shield")
        {
            Destroy(collision.gameObject);
            shield = true;
            shieldActivated();
        }
        else if(collision.gameObject.tag == "Obsticle" && shield == false)
        {
            Debug.Log("END");
            gc.EndGame();
        }
        else if (collision.gameObject.tag == "ToSave")
        {
            collision.gameObject.transform.parent.GetComponent<PanelControllerForSaveCreaturesMode>().creaturesToSave.Remove(collision.gameObject);
            Destroy(collision.gameObject); //animacija pre Destory-a

        }
    }


    public void startBoost()
    {
        boosted = true;
        StartCoroutine("waitThenDisableBoost");

    }

    IEnumerator waitThenDisableBoost()
    {
        int counter = 0;
        gc.bckPanels.GetComponent<BckPanelsController>().speed += 0.3f;
        while (counter <= 10)
        {
            counter++;
            yield return new WaitForSeconds(1f);
            gc.points += 10;
        }
        gc.bckPanels.GetComponent<BckPanelsController>().speed = gc.bckPanels.GetComponent<BckPanelsController>().prevSpeed;
        boosted = false;
    }

    IEnumerator parachuteAbility()
    {
        parachuteImageIcon.fillAmount = 0;
        parachuteReady = false;
        yield return new WaitForSeconds(4f);
        gc.parachuteActivated = false;
    }

    public void startParachute()
    {
        if (parachuteReady)
        {
            gc.parachuteActivated = true;
            StartCoroutine("parachuteAbility");
            StartCoroutine("refreshParachute");
        }
    }

    IEnumerator refreshParachute()
    {
        int counter = 0;
        while (counter < 20)
        {
            yield return new WaitForSeconds(1f);
            counter++;
            parachuteImageIcon.fillAmount += 0.5f / 10f;
            Debug.Log("Counter " + counter);
        }
        parachuteReady = true;
    }

    IEnumerator shieldActivated()
    {
        int counter = 0;
        while (counter <= 10)
        {
            counter++;
            yield return new WaitForSeconds(1f);
            gc.points += 10;
        }
        shield = false;
    }
}
