using UnityEngine;
using TMPro;
using UnityEngine.UI;  // For accessing the Button and Image components

public class VoiceOverHighlighter : MonoBehaviour
{
    public AudioSource audioSource;        // Audio source for the voice-over
    public TextMeshProUGUI textComponent;  // Text component displaying the text
    public Button toggleButton;            // Reference to the button
    public Sprite playButtonSprite;       // Sprite for the play button
    public Sprite pauseButtonSprite;      // Sprite for the pause button
    
    private string[] words = {"        Basketball", "was", "invented", "in", "December", "1891", "by James Naismith,", "a Canadian", "physical education", "instructor", "at the YMCA", "International", "Training School", "in Springfield,", "Massachusetts.", "Tasked by", "his superior,", "Dr. Luther", "H. Gulick,","to create", "an indoor game", "that would", "keep young", "men active", "during the", "cold winter", "months,", "Naismith","set out", "to design","a sport", "that emphasized", "skill", "rather than", "brute", "strength.", "Drawing", "inspiration", "from a","childhood game","called","'Duck on", "a Rock',", "Naismith", "developed", "the basic","rules","of","basketball,", "which","involved","players", "throwing","a ball", "into","a raised","peach","basket.", "The first","game","was ","played", "with nine","players", "on","each ","team,", "and the","sport", "quickly","gained ","popularity."};
    private float[] wordTimestamps = { 1.38f, 1.99f, 2.58f, 2.65f, 2.90f, 3.50f, 4.34f, 5.65f, 6.30f, 7.25f, 7.81f, 9.04f, 9.72f, 11.30f, 11.73f, 13.11f, 13.55f, 15.01f, 15.70f, 16.20f, 17.05f, 17.44f, 18.15f, 18.53f, 19.09f, 19.67f, 20.17F, 21.11F, 21.97F, 22.20f, 22.74f, 22.95f, 23.99f, 25.16f ,25.99f, 26.16f, 26.53f, 27.55f, 28.15f, 28.48f, 29.16f, 29.96f,30.30f,31.86f,32.41f,32.85f,33.12f,33.37f,33.91f,34.46f,34.85f,35.33f,35.76f,36.27f,36.44f,37.39f,37.76f,38.15f,39.11f,39.29f,39.50f,39.81f,40.29f,40.75f,41.01f,41.19f,41.48f,41.79f,42.09f,42.49f,42.75f,43.30f};
    private int currentWordIndex = 0;
    private bool isPaused = false;  // Flag to pause or resume the process

    private void Update()
    {
        // Check if the audio has finished playing and reset if needed
        if (!audioSource.isPlaying && currentWordIndex >= words.Length)
        {
            ResetHighlighting();   // Reset after finishing
            return;
        }

        // Only update if not paused and within words range
        if (!isPaused && currentWordIndex < words.Length && audioSource.time >= wordTimestamps[currentWordIndex])
        {
            HighlightWord(currentWordIndex);
            currentWordIndex++;
        }
    }

    private void HighlightWord(int index)
    {
        // Rebuild the text with the current word highlighted
        string highlightedText = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (i == index)
                highlightedText += $"<color=#429EBD>{words[i]}</color> "; // Hex color for highlighting
            else
                highlightedText += $"{words[i]} ";
        }
        textComponent.text = highlightedText;
    }

    // Call this method to toggle pause/resume for both audio and highlighting
    public void TogglePausePlay()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the audio and stop highlighting
            audioSource.Pause();
            // Set button to play icon
            toggleButton.image.sprite = playButtonSprite;
        }
        else
        {
            // Resume the audio and highlighting from where it was
            audioSource.Play();
            // Set button to pause icon
            toggleButton.image.sprite = pauseButtonSprite;
        }
    }

    // Method to reset the highlighting and button to initial state
    private void ResetHighlighting()
    {
        isPaused = true;                     // Set to paused
        currentWordIndex = 0;                // Reset the word index
        audioSource.Stop();                  // Stop the audio
        textComponent.text = string.Join(" ", words); // Reset text to initial unhighlighted state
        toggleButton.image.sprite = playButtonSprite; // Set button to play icon
    }
}
