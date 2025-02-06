using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateX : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 30f;

    void Update()
    {
        // Check if there's at least one touch on the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // If the touch is moving, calculate the rotation based on the horizontal movement
            if (touch.phase == TouchPhase.Moved)
            {
                // Rotate the object based on the horizontal delta movement
                float rotationZ = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;

                // Rotate around the Z-axis
                transform.Rotate(0, 0, -rotationZ);
            }
        }
    }
}