using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{
    public List<GameObject> buildingList = new List<GameObject>();
    public List<GameObject> buildingSelected = new List<GameObject>();
    private static BuildingSelection _instance;
    public static BuildingSelection Instance { get { return _instance; } }

    private void Awake()
    {
        // if an instance of this already exists and it isn't this one
        if (_instance != null && _instance != this)
        {
            // we destroy this instance
            Destroy(this.gameObject);
        }
        else
        {
            // make this the instance
            _instance = this;
        }
    }

    public void ClickSelect(GameObject go_building)
    {
        Deselect();
        buildingSelected.Add(go_building);
        go_building.transform.GetChild(0).gameObject.SetActive(true);


        UnitSelections.Instance.DeselectAll();
    }
    public void Deselect()
    {
        foreach (var building in buildingSelected)
        {
            building.transform.GetChild(0).gameObject.SetActive(false); // child(0) = select green

        }
        buildingSelected.Clear();
    }
}
