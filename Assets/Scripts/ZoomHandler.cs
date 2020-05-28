using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Animations;

public class ZoomHandler : MonoBehaviour
{
    float currentScaleX;
    float currentScaleY;
    public float maxScaleX;
    public float minScaleX;
    public float maxScaleY;
    public float minScaleY;

    //public RectTransform currentTransform;
    //Transform LastTransform;
    //PositionConstraint positionConstraint;
    //TO-DO- find a way to lock rectTransform whilst taking input from scroll wheel
    void Awake()
    {
        currentScaleX = gameObject.transform.position.x;
        currentScaleY = gameObject.transform.position.y;
        //positionConstraint = gameObject.GetComponent<PositionConstraint>();
    }

    void Update()
    {
        //currentTransform = gameObject.GetComponent<RectTransform>();
        HandleMouse();
    }

    void HandleMouse()
    {
        //LastTransform.anchoredPosition = currentTransform.anchoredPosition;
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            //positionConstraint.constraintActive = true;
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            currentScaleX += scroll;
            currentScaleY += scroll;
            if (currentScaleX >= maxScaleX)
            {
                currentScaleX = maxScaleX;
            }
            if (currentScaleX <= minScaleX)
            {
                currentScaleX = minScaleX;
            }
            if (currentScaleY >= maxScaleY)
            {
                currentScaleY = maxScaleY;
            }
            if (currentScaleY <= minScaleY)
            {
                currentScaleY = minScaleY;
            }
            gameObject.transform.localScale = new Vector2(currentScaleX, currentScaleY);
            //currentTransform.anchoredPosition = LastTransform.anchoredPosition;

        }
        /*else if(Input.GetAxis("Mouse ScrollWheel")==0)
        {
            positionConstraint.constraintActive = false;
        }
        */
    }
}