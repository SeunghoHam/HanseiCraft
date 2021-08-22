using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClick : MonoBehaviour
{
    private Camera camera;
    //public GameObject groundMarker;

    public LayerMask buildingLayer;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        click_Building();
    }
    void click_Building()
    {
      

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingLayer))
            {
                BuildingSelection.Instance.ClickSelect(hit.collider.gameObject);
            }
            else
            {
                BuildingSelection.Instance.Deselect();
            }
        }

    }
}
