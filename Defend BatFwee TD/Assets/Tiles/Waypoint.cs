using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Turret[] turretPrefab;
    [SerializeField] private bool isPlaceable;
    public bool IsPlaceable { get => isPlaceable; }
    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        int turretNum;
        if (gameManager != null)
        {
            turretNum = gameManager.SelectedTurret;
        }
        else
        {
            turretNum = 0;
        }

        if (isPlaceable && !gameManager.isOpeningOption)
        {
            bool isPlaced = turretPrefab[turretNum].CreateTurret(turretPrefab[turretNum], transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
