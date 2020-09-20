using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BckPanelsController : MonoBehaviour {

    public GameplayController gc;
    public float speed = 0.03f;
    public float delay = 10f;
    public float prevSpeed = 0.03f;

    public List<GameObject> creaturesToSave;

    public float meters = 0;
    float startTime;
    float currentTime;

    public Text metersLabel;


    // Use this for initialization
    void Start () {
        startTime = Time.time;
        currentTime = Time.time;
        StartCoroutine("waitFor10secAndChangeSpeed");
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, 0.03f, 0);

        currentTime = Time.time;
        meters += (speed * (currentTime - startTime))/10;
        metersLabel.text = "Distance: " + meters.ToString(); //razmisliti o tome kako  ce chalangi ici,kada se predje npr 100 dali posle 200 prelazi jos jedan ili se ceka sledeci game da bi mogao da predje sledeci chalange

    }

    IEnumerator waitFor10secAndChangeSpeed()
    {
        //ovo se podesava ako se brzina sporo ili brzo povecava
        while (true)
        {
            float speedToAdd = 0.015f;
            yield return new WaitForSeconds(delay);
            delay = delay + delay/2;

            if (speed < 1)
            {
                speed = speed + speedToAdd;
                prevSpeed = prevSpeed + speedToAdd;
                gc.charController.moveSpeed += 0.2f;
            }
            else if (speed < 2)
            {
                speed = speed + speedToAdd / 2;
                prevSpeed = prevSpeed + speedToAdd;
                gc.charController.moveSpeed += 0.1f;
            }
            else
            {
                speed = speed + speedToAdd / 3;
                prevSpeed = prevSpeed + speedToAdd;
                gc.charController.moveSpeed += 0.05f;
            }
            gc.pointsToAdd += 1;
           
        }
        
    }

}
