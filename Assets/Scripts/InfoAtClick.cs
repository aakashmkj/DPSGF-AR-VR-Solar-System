using UnityEngine;
using TMPro;
using System.IO;

public class DisplayTextFromFile : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Reference to the TextMeshProUGUI component
    public int messageIndex; // Set the index in the Inspector for each object
    private string[] messages;

    private void Start()
    {
        // Load messages from the file into an array
        LoadMessagesFromFile("Assets/Messages.txt");

        // Ensure the display text is empty initially
        if (displayText != null)
        {
            displayText.text = "";
        }
    }

    private void LoadMessagesFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            messages = File.ReadAllLines(filePath);
        }
        else
        {
            Debug.LogError("Text file not found at: " + filePath);
        }
    }

    private void OnMouseDown()
    {
        // Check if the text should be displayed or hidden
        if (displayText != null && messages != null && messageIndex < messages.Length)
        {
            // If the displayText is already showing, hide it
            if (displayText.text == messages[messageIndex])
            {
                displayText.text = ""; // Hide the text
            }
            else
            {
                displayText.text = messages[messageIndex]; // Show the message for this object
            }
        }
    }

    private void Update()
    {
        // Hide text if the user clicks away from the object
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject != gameObject && displayText != null)
                {
                    displayText.text = ""; // Clear text when clicking elsewhere
                }
            }
            else
            {
                displayText.text = ""; // Clear text if clicking on empty space
            }
        }
    }
}
