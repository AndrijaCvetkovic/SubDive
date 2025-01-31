﻿using System.Collections;
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

            gc.AddNewPanelAndDeleteFristOne();
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
            //ovde je kraj
            gc.EndGame();
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
