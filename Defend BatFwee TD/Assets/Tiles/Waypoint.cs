using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Turret[] turretPrefab;
    [SerializeField] private bool isPlaceable;
    public bool IsPlaceable { get => isPlaceable; }
    [SerializeField] private int turretNum = 0;

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = turretPrefab[turretNum].CreateTurret(turretPrefab[turretNum], transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
