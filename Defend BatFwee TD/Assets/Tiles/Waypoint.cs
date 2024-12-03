using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Turret[] turretPrefab;
    [SerializeField] private bool isPlaceable;
    [SerializeField] private GameObject parentForTurret;
    [SerializeField] private ParticleSystem spawnCircle;

    public bool IsPlaceable { get => isPlaceable; }
    private LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        var spawnCircleEmision = spawnCircle.emission;
        if (IsPlaceable)
        {
            SetTurretsParent();
            spawnCircleEmision.enabled = true;
        }
        else
        {
            spawnCircle.gameObject.SetActive(false);
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
            spawnCircle.gameObject.SetActive(false);
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
