using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogChangeColor : MonoBehaviour
{
    // The color #003D51 (in Unity, this is represented as RGB(0, 61, 81))
    public Color targetColor = new Color(0f / 255f, 61f / 255f, 81f / 255f);

    // The target name of the objects we want to change
    public string targetName = "Dialogue Box";

    void Start()
    {
        // Find all objects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true); // 'true' includes inactive objects

        // Loop through all objects to find those with the name "Dialogue Box"
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == targetName)
            {
                // Try to get the Image component (for UI objects)
                Image imageComponent = obj.GetComponent<Image>();
                
                // If an Image component exists
                if (imageComponent != null)
                {
                    // Change the Image's color if no material is present
                    if (imageComponent.material == null)
                    {
                        imageComponent.color = targetColor;
                        Debug.Log("Changed color of Image component on: " + obj.name);
                    }
                    else
                    {
                        // Change the material's color if a material is assigned
                        imageComponent.material.color = targetColor;
                        Debug.Log("Changed material color on Image component of: " + obj.name);
                    }
                }
                else
                {
                    // Try to get SpriteRenderer (for 2D sprites)
                    SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

                    if (spriteRenderer != null)
                    {
                        // Change the SpriteRenderer's color if no material is present
                        if (spriteRenderer.material == null)
                        {
                            spriteRenderer.color = targetColor;
                            Debug.Log("Changed color of SpriteRenderer on: " + obj.name);
                        }
                        else
                        {
                            // Change the material's color if a material is assigned
                            spriteRenderer.material.color = targetColor;
                            Debug.Log("Changed material color on SpriteRenderer of: " + obj.name);
                        }
                    }
                    else
                    {
                        Debug.LogWarning("No Image or SpriteRenderer found on: " + obj.name);
                    }
                }
            }
        }
    }
}