using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenModeController : MonoBehaviour
{
    public Toggle windowedToggle;
    public Toggle fullscreenToggle;

    void Start()
    {
        // Set default screen mode to windowed
        Screen.fullScreenMode = FullScreenMode.Windowed;
        windowedToggle.isOn = true;
        fullscreenToggle.isOn = false;

        // Add listeners to the toggles
        windowedToggle.onValueChanged.AddListener(OnWindowedToggleChanged);
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggleChanged);
    }

    void OnWindowedToggleChanged(bool isOn)
    {
        if (isOn)
        {
            // If windowed toggle is selected, set to windowed mode and deselect fullscreen toggle
            Screen.fullScreenMode = FullScreenMode.Windowed;
            fullscreenToggle.isOn = false;
        }
    }

    void OnFullscreenToggleChanged(bool isOn)
    {
        if (isOn)
        {
            // If fullscreen toggle is selected, set to fullscreen mode and deselect windowed toggle
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            windowedToggle.isOn = false;
        }
    }
}
