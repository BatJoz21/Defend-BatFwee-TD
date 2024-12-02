using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Turret[] turretPrefab;
    [SerializeField] private bool isPlaceable;
    [SerializeField] private GameObject parentForTurret;
    public bool IsPlaceable { get => isPlaceable; }
    private LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        if (IsPlaceable)
        {
            SetTurretsParent();
        }
    }

    private void OnMouseDown()
    {
        int turretNum;
        if (levelManager != null)
        {
            turretNum = levelManager.SelectedTurret;
        }
        else
        {
            turretNum = 0;
        }

        if (isPlaceable && !levelManager.isOpeningOption)
        {
            bool isPlaced = turretPrefab[turretNum].CreateTurret(turretPrefab[turretNum], transform.position);
            isPlaceable = !isPlaced;
        }
    }

    private void SetTurretsParent()
    {
        foreach (Turret turret in turretPrefab)
        {
            turret.turretsParent = parentForTurret;
        }
    }
}
