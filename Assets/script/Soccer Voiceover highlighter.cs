using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoccerVoiceoverhighlighter : MonoBehaviour
{
    public AudioSource audioSource;        // Audio source for the voice-over
    public TextMeshProUGUI textComponent;  // Text component displaying the text
    public Button toggleButton;            // Reference to the button
    public Sprite playButtonSprite;       // Sprite for the play button
    public Sprite pauseButtonSprite;      // Sprite for the pause button
    
    private string[] words = {
        "Football","also","known","as","soccer,","is","the","most","popular","sport","worldwide,",
        "played","by","two","teams","of","11","players","aiming","to","score","goals","by","getting",
        "the","ball","into","the","opposing","team’s","net","using","any","part","of","their","body",
        "except","their","hands","and","arms.","Only","the","goalkeeper","can","use","their","hands",
        "within","the","penalty","area.","The","modern","version","of","the","game","began","in","England",
        "in","1863,","when","the","Football","Association (FA)","was","formed","to","create","official","rules,",
        "separating","it","from","rugby.","Earlier","forms","of","football","were","played","in","medieval",
        "towns","with","different","local","rules.","The","standardized","rules,","called","the","Cambridge",
        "rules,","were","first","created","by","students","at","the","University","of","Cambridge.","FIFA,",
        "established","in","1904,","now","oversees","the","sport","globally.","Football","is","played",
        "everywhere","from","official","fields","to","streets","and","beaches,","with","the","FIFA","World",
        "Cup","as","its","biggest","tournament,","attracting","billions","of","viewers."
        };
    private float[] wordTimestamps = {
         1.6f,2.4f,2.7f,2.8f,3.2f,4.2f,4.3f,4.5f,4.9f,5.3f,5.8f,6.9f,7.1f,7.3f,7.5f,7.7f,8.3f,8.6f,9.2f,9.3f,
         9.7f,10.0f,10.3f,10.6f,10.7f,11.0f,11.5f,11.6f,12.0f,12.6f,12.8f,13.9f,14.2f,14.4f,14.5f,14.8f,15.1f,
         15.5f,15.9f,16.3f,16.4f,16.7f,17.9f,18.1f,18.7f,18.9f,19.2f,19.5f,19.8f,20.1f,20.3f,20.8f,21.3f,
         22.6f,22.9f,23.2f,23.3f,23.5f,23.8f,24.1f,24.3f,24.8f,25.1f,26.2f,27.3f,27.5f,27.7f,28.5f,29.1f,29.3f,
         29.5f,29.8f,30.5f,30.9f,32.4f,32.5f,32.8f,33.3f,35.2f,35.6f,35.7f,36.4f,36.7f,36.9f,37.1f,37.7f,38.2f,
         38.8f,39.4f,39.9f,40.3f,41.6f,42.4f,42.8f,43.6f,43.8f,44.4f,44.7f,45.6f,46.0f,46.6f,46.8f,47.5f,47.7f,
         47.8f,48.6f,48.8f,49.7f,51.0f,52.0f,52.1f,53.2f,54.2f,54.8f,55.1f,55.5f,56.1f,58.2f,58.4f,58.7f,59.1f,
         60.4f,61.0f,61.5f,62.0f,62.6f,63.1f,63.6f,64.8f,64.9f,65.2f,65.5f,65.8f,66.0f,66.4f,67.0f,67.4f,68.5f,
         69.1f,69.3f,69.9f
      
         };
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
