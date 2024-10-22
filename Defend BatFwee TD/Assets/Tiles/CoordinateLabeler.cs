using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private int snapValue;
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color blockedColor = Color.gray;

    private TextMeshPro label;
    private Vector2Int coordinate = new Vector2Int();
    private Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();
    }

    private void DisplayCoordinates()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / snapValue);
        coordinate.y = Mathf.RoundToInt( transform.parent.position.z / snapValue);

        label.text = $"{coordinate.x}, {coordinate.y}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }

    private void ColorCoordinates()
    {
        if (!waypoint.IsPlaceable)
        {
            label.color = blockedColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
