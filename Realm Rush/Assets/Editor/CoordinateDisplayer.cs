using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateDisplayer : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;

    WayPoint wayPoint;

    TextMeshPro lable;
    Vector2Int coordinates = new Vector2Int();
    private void Awake()
    {
        lable = GetComponent<TextMeshPro>();
        wayPoint = GetComponentInParent<WayPoint>();
        DisplayCoordinates();
        lable.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {       
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            lable.enabled = true;
        }
        SetLableColor();
        ToggleLables();
    }
    void ToggleLables()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lable.enabled = !lable.IsActive();
        }
    }
    private void SetLableColor()
    {
        if (wayPoint.IsPalceable)
        {
            lable.color = defaultColor;
        }
        else
        {
            lable.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        lable.text = coordinates.x+", "+coordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
