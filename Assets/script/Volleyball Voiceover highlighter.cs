using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolleyballVoiceoverhighlighter : MonoBehaviour
{
    public AudioSource audioSource;        // Audio source for the voice-over
    public TextMeshProUGUI textComponent;  // Text component displaying the text
    public Button toggleButton;            // Reference to the button
    public Sprite playButtonSprite;       // Sprite for the play button
    public Sprite pauseButtonSprite;      // Sprite for the pause button
    
    private string[] words = {
        "Volleyball","originated","in the","United","States","in","1895,","when", 
        "William", "G. Morgan,", "a physical", "education", "director","at", "the",
        "YMCA", "in Holyoke,","Massachusetts,", "created", "the","game","as a","less",
        "physically","demanding","alternative","to basketball.","Initially","called",
        "'mintonette,'","the game","combined","elements","from","tennis,","basketball,",
        "and handball.","The name","was","changed to","'volleyball'","following a","demonstration",
        "game","where a","spectator","noted","that","the players","were","volleying","the ball","back and",
        "forth","over","the net.\n\n",
        
        "The sport","quickly","grew","in","popularity","and","spread","internationally.",
        "By","1947,","the Federation","Internationale","de Volleyball (FIVB)","was established","to govern",
        "the sport,","and","the first","World","Championships","took place","in 1949.","Volleyball","was",
        "introduced","as an","Olympic","sport in","1964","at the","Tokyo","Games,","cementing","its status",
        "as a","global","phenomenon."
        };
    private float[] wordTimestamps = {
         1.3f,2.0f,2.4f, 2.9f, 3.3f, 3.7f, 4.1f, 5.7f, 6.2f, 6.8f, 7.5f, 7.9f, 8.5f, 8.9f, 9.0f, 9.5f, 10.4f,10.8f,12.1f,12.3f,12.4f,13.0f,
         13.3f,13.8f,14.2f,15.1f,16.1f,17.8f,18.1f,18.8f,19.8f,20.3f,20.9f,21.0f,21.6f, 22.5f,23.3f,24.5f,24.6f,25.3f,25.0f,26.6f,27.2f,
         27.5f,27.8f,28.5f, 28.9f,29.4f, 30.0f, 30.3f, 30.6f,31.1f,31.5f,31.9f,32.3f,32.6f,34.0f,34.5f,34.7f,35.4f,36.1f,36.5f,37.0f,37.9f,38.9f,39.8f,41.2f,41.8f,
         42.6f, 43.5f, 44.1f,44.3f, 45.0f, 45.3f, 45.6f, 46.2f, 46.9f, 47.9f,49.3f, 49.5f, 50.0f,  50.3f,50.7f, 51.4f, 52.5f, 53.3f, 53.6f, 54.0f, 54.9f, 55.6f, 56.0f, 56.5f, 57.2f      
         
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
