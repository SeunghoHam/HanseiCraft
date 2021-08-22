using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera camera;

    // graphical
    [SerializeField] RectTransform boxVisual;

    // logical
    Rect selectionBox;

    Vector2 startPos;
    Vector2 endPos;

    void Start()
    {
        camera = Camera.main;
        startPos = Vector2.zero;
        endPos = Vector2.zero;
    }

    
    void Update()
    {
        // when clicked
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            selectionBox = new Rect(); // selectionBox = Rect형으로 선언되있다
        }
        // when holding dragging
        if(Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }

        // when release click
        if(Input.GetMouseButtonUp(0))
        {
            Selectunits();
            startPos = Vector2.zero;
            endPos = Vector2.zero;
            DrawVisual();
              
        }
    }
    void DrawVisual()
    {
        Vector2 boxStart = startPos;
        Vector2 boxEnd = endPos;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter; // boxVisual = RectTransform형으로 선언되있다.

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
        boxVisual.sizeDelta = boxSize;
    }
    void DrawSelection()
    {
        // do X calculations
        if(Input.mousePosition.x < startPos.x)
        {
            // dragging left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPos.x;
        }
        else
        {
            // dragging right
            selectionBox.xMin = startPos.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        if(Input.mousePosition.y < startPos.y)
        {
            // dragging down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPos.y;
        }
        else
        {
            // draggin up
            selectionBox.yMin = startPos.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
        // do Y calculations
    }
    void Selectunits()
    {
        // loop thru all the units
        foreach (var unit in UnitSelections.Instance.unitList)
        {
            // if unit is within the bounds of the selection rect
            if(selectionBox.Contains(camera.WorldToScreenPoint(unit.transform.position)))
            {
                // if any unit is within the selection add them to selection
                UnitSelections.Instance.DragSelect(unit);
            }
        }
    }
}
