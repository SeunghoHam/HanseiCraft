using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BuildingSelection.Instance.buildingList.Add(this.gameObject);
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        BuildingSelection.Instance.buildingList.Remove(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
