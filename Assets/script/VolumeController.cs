using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.volume = 5.0f; // Set the volume above 1.0
    }
}
