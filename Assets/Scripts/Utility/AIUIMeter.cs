using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This class represents a UI meter that includes a label, slider, and image
public class AIUIMeter : MonoBehaviour
{
    // Reference to the TextMeshPro label component in the UI
    [SerializeField] TMP_Text label;

    // Reference to the Slider component in the UI
    [SerializeField] Slider slider;

    // Reference to the Image component in the UI
    [SerializeField] Image image;

    // Property to set the position of the meter's RectTransform
    public Vector3 position
    {
        set
        {
            // Draw a debug line from the specified position to a point 3 units above it
            Debug.DrawLine(value, value + Vector3.up * 3);

            // Convert the world position to a viewport point
            Vector2 viewportPoint = Camera.main.WorldToViewportPoint(value);

            // Set the anchor points of the RectTransform to the converted viewport point
            GetComponent<RectTransform>().anchorMin = viewportPoint;
            GetComponent<RectTransform>().anchorMax = viewportPoint;
        }
    }

    // Property to set the value of the slider
    public float value
    {
        set
        {
            slider.value = value;
        }
    }

    // Property to set the text of the label
    public string text
    {
        set
        {
            label.text = value;
        }
    }

    // Property to set the visibility of the meter
    public bool visible
    {
        set
        {
            gameObject.SetActive(value);
        }
    }

    // Property to set the alpha value of the image's color
    public float alpha
    {
        set
        {
            // Get the current color of the image
            Color color = image.color;

            // Set the alpha value of the color
            color.a = value;

            // Apply the new color to the image
            image.color = color;
        }
    }
}
