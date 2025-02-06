using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateVertical : MonoBehaviour
{
     public float rotationSpeed = 200f; // Adjust to control rotation sensitivity
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        endTouchPosition = touch.position;
                        float swipeDistanceY = endTouchPosition.y - startTouchPosition.y;
                        float rotationAmount = swipeDistanceY * rotationSpeed * Time.deltaTime;
                        
                        // Rotate the object vertically around the X-axis
                        transform.Rotate(rotationAmount, 0, 0);

                        // Update start position for smoother rotation
                        startTouchPosition = endTouchPosition;
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }
}
