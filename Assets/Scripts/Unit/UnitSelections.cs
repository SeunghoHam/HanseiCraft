using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static  UnitSelections Instance { get { return _instance;  } }

    void Awake()
    {
        // if an instance of this already exists and it isn't this one
        if(_instance != null && _instance != this)
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
    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!unitsSelected.Contains(unitToAdd)) // unitsSelected List가 unitToAdd 게임오브젝트를 포함하고 있지 않다면
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitsSelected.Remove(unitToAdd); // 포함하고 있다면 List에서 제외시킨다.
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void DragSelect(GameObject unitToAdd)
    {
        if(!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
    }
    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitsSelected.Clear(); // unitsSelected = List
    }
    public void Deselect(GameObject unitToDeselect)
    {

    }
}
