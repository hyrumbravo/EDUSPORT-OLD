using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;  // Speed of rotation
    private Vector3 previousPosition;   // To store the last touch/mouse position

    void Update()
    {
        // Check for touch input on mobile or mouse input on desktop
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            // Determine the position to check for input
            Vector3 inputPosition;

            // Use touch input if available
            if (Input.touchCount > 0)
            {
                inputPosition = Input.GetTouch(0).position; // Get the position of the first touch
            }
            else
            {
                inputPosition = Input.mousePosition; // Use mouse position if no touch
            }

            // Create a ray from the camera to the input position
            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
            RaycastHit hit;

            // Check if the ray hits the Box Collider of this object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit is this game object
                if (hit.transform == transform)
                {
                    // Detect movement by comparing the current position with the previous position
                    Vector3 delta = inputPosition - previousPosition;

                    // Rotate object based on input (horizontal and vertical swipe)
                    float rotationX = delta.x * rotationSpeed * Time.deltaTime;
                    float rotationY = delta.y * rotationSpeed * Time.deltaTime;

                    // Apply rotation to the object (around the Y and X axes)
                    transform.Rotate(Vector3.up, -rotationX, Space.World);  // Rotate around Y-axis
                    transform.Rotate(Vector3.right, rotationY, Space.World); // Rotate around X-axis
                }
            }

            // Store the current input position for the next frame
            previousPosition = inputPosition;
        }
        else
        {
            // Reset the previous position if no input is detected
            previousPosition = Input.mousePosition;
        }
    }
}
