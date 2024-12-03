using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int wallHealth = 100;

    private LevelManager levelManager;
    private AudioManager audioManager;

    public int WallHealth { get => wallHealth; }

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        CheckInstance();
    }

    public void DamagingWall(int damage)
    {
        wallHealth -= damage;
        if (wallHealth <= 0)
        {
            audioManager.PlaySFX(1);
            levelManager.GameOver();
        }
    }

    private void CheckInstance()
    {
        if (audioManager == null || levelManager == null)
        {
            levelManager = FindObjectOfType<LevelManager>();
            audioManager = FindObjectOfType<AudioManager>();
        }
    }
}
