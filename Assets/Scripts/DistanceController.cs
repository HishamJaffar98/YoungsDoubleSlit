using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour
{
    [SerializeField] Slider distanceSlider;

    List<GameObject> children = new List<GameObject>();
    float originalHeight1;
    float originalHeight2;
    void Start()
    {
        for(int i=0;i<gameObject.transform.childCount;i++)
        {
            children.Add(gameObject.transform.GetChild(i).gameObject);
        }
        originalHeight1 = children[1].transform.position.y;
        originalHeight2 = children[3].transform.position.y;     
    }


    void Update()
    {
        children[1].transform.position = new Vector3(children[1].transform.position.x,originalHeight1 + distanceSlider.value, children[1].transform.position.z);
        children[3].transform.position = new Vector3(children[3].transform.position.x, originalHeight2 - distanceSlider.value, children[3].transform.position.z);
    }
}
