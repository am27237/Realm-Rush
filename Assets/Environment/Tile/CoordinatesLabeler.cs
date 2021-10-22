using TMPro;
using UnityEngine;

[ExecuteAlways] //will execute even in edit mode
[RequireComponent(typeof(TextMeshPro))]
public class CoordinatesLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        DisplayCoordinates();   //DisplayCoordinates() method in Awake methode to prevent breaking of the code during play mode

    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ToggleLabel();
        SetLabelColor();
    }

    private void SetLabelColor()
    {
        

        if (gridManager == null) { return; }

        Node node = gridManager.GetNodes(coordinates);

        if (node == null) { return; }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }

        else if (node.isPath)
        {
            label.color = pathColor;
        }

        else if (node.isExplored)
        {
            label.color = exploredColor;
        }

        else
        {
            label.color = default;
        }
    }

    private void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.position.x / UnityEditor.EditorSnapSettings.move.x); //position divided to snapeditor settings value to display 1:1 ratio instead of 1:10
        coordinates.y = Mathf.RoundToInt(transform.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + ", " + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString(); //to update the names of the gameobjects in the heirarchy
    }
}
