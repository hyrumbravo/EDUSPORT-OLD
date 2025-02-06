using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responsive3DObject : MonoBehaviour
{
    public Vector3 baseScale = new Vector3(1, 1, 1); // Set your default scale here
    public float referenceWidth = 1080; // The width of the reference screen
    public float referenceHeight = 1920; // The height of the reference screen

    void Start()
    {
        UpdateScale();
    }

    void UpdateScale()
    {
        float widthRatio = Screen.width / referenceWidth;
        float heightRatio = Screen.height / referenceHeight;
        float scaleRatio = Mathf.Min(widthRatio, heightRatio); // Keep aspect ratio

        transform.localScale = baseScale * scaleRatio;
    }

    void Update()
    {
        UpdateScale();
    }
}
