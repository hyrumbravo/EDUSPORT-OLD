using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNavigationBar : MonoBehaviour
{
    void Start()
    {
        // Initially set the screen to show the navigation bar
        ShowNavigation();
    }

    void Update()
    {
        // Check for touch or mouse input
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // Get the touch or mouse position
            Vector2 touchPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;

            // Check if the touch/mouse position is near the bottom of the screen
            if (touchPosition.y < Screen.height * 0.1f) // Adjust this value as needed
            {
                ShowNavigation();
            }
        }
    }

    private void ShowNavigation()
    {
        // Set the navigation bar and status bar to be visible
        Screen.fullScreenMode = FullScreenMode.Windowed; // Windowed mode allows navigation bar to show
        Screen.fullScreen = false; // Ensure it is not in full-screen mode
    }
}
