using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    MainMenuUIController mmUIController;
    UIController uiController;
    bool lightSwitchToggled = true;
    bool menuOpened = false;
    bool explanationStarted = false;
    void Start()
    {
        mmUIController = FindObjectOfType<MainMenuUIController>();
        uiController = FindObjectOfType<UIController>();
    }

    public void StartButton()
    {
        mmUIController.ToggleButtonInteractivity();
        StartCoroutine(LevelManager.LoadNextLevel());
    }

    public void QuitButton()
    {
        mmUIController.ToggleButtonInteractivity();
        StartCoroutine(LevelManager.QuitApplication());
    }

    public void ToggleLightSwitch()
    {
        if(!lightSwitchToggled)
        {
            uiController.ToggleLightSwitchObjects(true);
            lightSwitchToggled = true;
        }
        else
        {
            uiController.ToggleLightSwitchObjects(false);
            lightSwitchToggled = false;
        }
    }

    public void BackButton()
    {
        StartCoroutine(LevelManager.LoadPrevLevel());
    }

    public void MenuButton()
    {
        if(!menuOpened)
        {
            StartCoroutine(uiController.ToggleMenu(true));
            menuOpened = true;
        }
        else
        {
            uiController.ToggleExplanation(true);
            uiController.ResetSliders();
            StartCoroutine(uiController.ToggleMenu(false));
            menuOpened = false;
        }
    }

    public void ExplanationButton()
    {
        if(!explanationStarted)
        {
            uiController.ToggleExplanation(false);
            explanationStarted = true;
        }
        else
        {
            uiController.ToggleExplanation(true);
            explanationStarted = false;
        }
    }

    public void CameraAngleButton()
    {
        uiController.ChangeCameraButtonTransparency();
        uiController.ToggleCameraAngle();
    }
}
