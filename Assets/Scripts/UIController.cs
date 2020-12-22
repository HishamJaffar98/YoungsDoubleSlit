using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Light Switch Components")]
    [SerializeField] Sprite[] lightSwitchSprites;
    [SerializeField] AudioClip[] lightSounds;
    [SerializeField] GameObject lightSwitch;
    [SerializeField] TextMeshProUGUI lightToggleText;
    [SerializeField] GameObject[] lights;

    [Header("Experiment Menu Components")]
    [SerializeField] GameObject menuButton;
    [SerializeField] Animator menuAnimator;
    [SerializeField] Animator mainAnimator;
    [SerializeField] Slider[] menuSliders;
      
    [Header("Explanation Button Components")]
    [SerializeField] TextMeshProUGUI explanationButtonText;

    [Header("Camera Angle Components")]
    [SerializeField] GameObject angleHandle;
    [SerializeField] GameObject[] cameras;
    List<GameObject> cameraAngles = new List<GameObject>();
    Color semiTransparent = new Color(1f, 1f, 1f, 0.2f);
    Color opaque = new Color(1f, 1f, 1f, 1f);

    [Header("Narrator Components")]
    [SerializeField] GameObject narrator;
    void Start()
    {
        for(int i=0;i<angleHandle.transform.childCount;i++)
        {
            cameraAngles.Add(angleHandle.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLightSwitchObjects(bool toggle)
    {
        if(toggle==true)
        {
            LightToggle(0, "Light On", true);
        }
        else
        {
            LightToggle(1, "Light Off", false);
        }
    }

    public IEnumerator ToggleMenu(bool toggleState)
    {
        if(toggleState==true)
        {
            yield return new WaitForSecondsRealtime(0f);
            menuButton.SetActive(!toggleState);
            menuAnimator.SetBool("menuOpened", toggleState);
            mainAnimator.SetBool("menuOpened", toggleState);
        }
        else if(toggleState==false)
        {
            menuAnimator.SetBool("menuOpened", toggleState);
            mainAnimator.SetBool("menuOpened", toggleState);
            yield return new WaitForSecondsRealtime(1.5f);
            menuButton.SetActive(!toggleState);
        }
        
    }

    public void ToggleExplanation(bool toggleState)
    {
        if(toggleState==true)
        {
            explanationButtonText.text = "START EXPLANATION";
            narrator.GetComponent<AudioSource>().Stop();
            FindObjectOfType<BGM>().GetComponent<AudioSource>().volume = 0.4f;
        }
        else
        {    
            explanationButtonText.text = "STOP EXPLANATION";
            narrator.GetComponent<AudioSource>().Play();
            FindObjectOfType<BGM>().GetComponent<AudioSource>().volume = 0.1f;
        }
    }

    public void ResetSliders()
    {
        foreach(Slider slider in menuSliders)
        {
            slider.value = 0f;
        }
    }

    public void ChangeCameraButtonTransparency()
    {
        foreach(GameObject angle in cameraAngles)
        {
            angle.GetComponent<Image>().color = semiTransparent;
            if(EventSystem.current.currentSelectedGameObject==angle)
            {
                angle.GetComponent<Image>().color = opaque;
            }
        }
    }

    public void ToggleCameraAngle()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "Angle1":
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
                cameras[2].SetActive(false);
                break;
            case "Angle2":
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
                cameras[2].SetActive(false);
                break;
            case "Angle3":
                cameras[0].SetActive(false);
                cameras[1].SetActive(false);
                cameras[2].SetActive(true);
                break;
        }
    }

    private void LightToggle(int arrayIndex, string textToBeDisplayed,bool gameObjectState)
    {
        lightSwitch.GetComponent<Image>().sprite = lightSwitchSprites[arrayIndex];
        gameObject.GetComponent<AudioSource>().PlayOneShot(lightSounds[arrayIndex]);
        lightToggleText.text = textToBeDisplayed;
        foreach (GameObject light in lights)
        {
            light.SetActive(gameObjectState);
        }
    }
}
