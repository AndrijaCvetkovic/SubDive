using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterContentController : MonoBehaviour
{

    public float spacing = 0;
    public int centeredObject = 0;
    public bool lerping = false;
    public Vector3 newPos;

    public GameObject btnLeft;
    public GameObject btnRight;

    private void Start()
    {
        Input.multiTouchEnabled = false;
        spacing = GetComponent<GridLayoutGroup>().spacing.x + GetComponent<GridLayoutGroup>().cellSize.x;
        newPos = transform.localPosition;
    }

    public void moveLeft()
    {
        if (centeredObject > 0)
        {
            btnRight.GetComponent<Button>().interactable = true;
            newPos.x += spacing;
            if (lerping == false)
                StartCoroutine(lerpToCenterNextObject(new Vector3(transform.localPosition.x - spacing, transform.localPosition.y, 0)));
            centeredObject -= 1;
        }

        if (centeredObject == 0)
        {
            btnLeft.GetComponent<Button>().interactable = false;
        }

    }

    public void moveRight()
    {

        if (centeredObject < transform.childCount - 1)
        {
            btnLeft.GetComponent<Button>().interactable = true;
            newPos.x -= spacing;
            if (lerping == false)
                StartCoroutine(lerpToCenterNextObject(new Vector3(transform.localPosition.x - spacing, transform.localPosition.y, 0)));
            centeredObject += 1;
        }

        if (centeredObject == transform.childCount - 1)
        {
            btnRight.GetComponent<Button>().interactable = false;
        }
    }

    IEnumerator lerpToCenterNextObject(Vector3 newPoss)
    {
        lerping = true;
        float speed = 2;
        
        while (Mathf.Abs(transform.localPosition.x - newPos.x) > 1f)
        {
            yield return new WaitForEndOfFrame();
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, 0.1f);
        }
        transform.localPosition = newPos;

        lerping = false;
    }

}
