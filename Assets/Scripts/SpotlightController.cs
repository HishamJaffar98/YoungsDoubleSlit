using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotlightController: MonoBehaviour
{
    [SerializeField] Slider frequencySlider;
    float initialRange;
    void Start()
    {
        initialRange = gameObject.GetComponent<Light>().range;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Light>().range = initialRange + frequencySlider.value;
    }
}
