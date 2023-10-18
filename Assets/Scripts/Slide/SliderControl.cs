using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderControl : MonoBehaviour
{
    Vector3 firstMousePos;
    Vector3 lastMousePos;
    float distance;
    public float maxValue, minValue;
    float xPos;
    Vector3 firstThisPos;
    bool slideActive;
    public int numberOfCorrect;

    void Update()
    {
        if (slideActive)
        {
            lastMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            distance = lastMousePos.x - firstMousePos.x;
            Slide(distance);
        }
    }

    public void OnMouseDown()
    {
        slideActive = true;
        firstMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        firstThisPos = transform.position;
    }
    private void OnMouseUp()
    {
        slideActive = false;
    }

    public void Slide(float value)
    {

        if (value < 0)
        {
            xPos = maxValue * (value * 10);
        }
        else
        {
            xPos = maxValue * (value * 10);
        }



        float a = xPos + firstThisPos.x;
        if (a > 5f)
        {
            a = 5f;
        }
        if (a < -5f)
        {
            a = -5f;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position,
                 new Vector3(a, transform.position.y, transform.position.z), 10);
    }

    public int Result;
    public void CalculateAccuracy()
    {
        Result = (numberOfCorrect * 100) / 15;
    }

}


