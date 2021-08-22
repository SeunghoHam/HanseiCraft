using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesSet : MonoBehaviour
{
    private Image image1;
    // Start is called before the first frame update
    void Start()
    {
        image1 = Resources.Load<Image>("Select/image1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
