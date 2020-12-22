using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] Button[] menuButtons;
    [SerializeField] AudioSource buttonSFXManager;
    [SerializeField] AudioClip[] buttonSounds;
    void Start()
    {
        
    }

    public void ToggleButtonInteractivity()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "StartButton")
        {
            menuButtons[0].interactable = true;
            menuButtons[1].interactable = false;

        }
        else if (EventSystem.current.currentSelectedGameObject.name == "QuitButton")
        {
            menuButtons[1].interactable = true;
            menuButtons[0].interactable = false;
        }
    }

    public void StartButtonFX()
    {
        buttonSFXManager.PlayOneShot(buttonSounds[0]);
    }

    public void QuitButtonFX()
    {
        buttonSFXManager.PlayOneShot(buttonSounds[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
