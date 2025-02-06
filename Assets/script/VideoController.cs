using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Reference to the VideoPlayer
    public RawImage rawImage;        // Reference to the RawImage
    public Button playPauseButton;  // Reference to the play/pause button
    public Button forwardButton;    // Reference to the forward button
    public Button backwardButton;   // Reference to the backward button
    public Sprite playIcon;         // Sprite for the play icon
    public Sprite pauseIcon;        // Sprite for the pause icon

    private bool isPlaying = false; // Tracks the playback state
    private const double skipTime = 5.0; // Time to skip in seconds

    void Start()
    {
        // Set up RawImage texture
        rawImage.texture = videoPlayer.targetTexture;

        // Set initial button states
        playPauseButton.image.sprite = playIcon;
        videoPlayer.Pause();

        // Add listeners to buttons
        playPauseButton.onClick.AddListener(TogglePlayPause);
        forwardButton.onClick.AddListener(SkipForward);
        backwardButton.onClick.AddListener(SkipBackward);
    }

    void Update()
    {
        // Ensure texture remains assigned during playback
        if (videoPlayer.isPlaying && rawImage.texture != videoPlayer.targetTexture)
        {
            rawImage.texture = videoPlayer.targetTexture;
        }
    }

    // Toggle between play and pause
    public void TogglePlayPause()
    {
        if (isPlaying)
        {
            PauseVideo();
        }
        else
        {
            PlayVideo();
        }
    }

    // Play the video
    public void PlayVideo()
    {
        videoPlayer.Play();
        playPauseButton.image.sprite = pauseIcon;
        isPlaying = true;
    }

    // Pause the video
    public void PauseVideo()
    {
        videoPlayer.Pause();
        playPauseButton.image.sprite = playIcon;
        isPlaying = false;
    }

    // Skip forward in the video
    public void SkipForward()
    {
        videoPlayer.time += skipTime;
    }

    // Skip backward in the video
    public void SkipBackward()
    {
        videoPlayer.time -= skipTime;

        // Ensure time doesn't go below zero
        if (videoPlayer.time < 0)
        {
            videoPlayer.time = 0;
        }
    }
}
