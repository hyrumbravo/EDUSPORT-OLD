using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    public float zoomSpeed = 0.01f;
    public float minScale = 0.5f;
    public float maxScale = 2f;

    void Update()
    {
        // Check if there are at least two touches on the screen
        if (Input.touchCount == 2)
        {
            // Get both touches
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Calculate the distance between the two touches in the current and previous frames
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

            float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
            float currentTouchDeltaMag = (touch1.position - touch2.position).magnitude;

            // Calculate the difference in distance between the two touches
            float deltaMagnitudeDiff = prevTouchDeltaMag - currentTouchDeltaMag;

            // Adjust the scale of the object
            float scaleFactor = 1 - deltaMagnitudeDiff * zoomSpeed;
            Vector3 newScale = transform.localScale * scaleFactor;

            // Clamp the scale to prevent over-zooming
            newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
            newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
            newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

            // Apply the new scale
            transform.localScale = newScale;
        }
    }
}