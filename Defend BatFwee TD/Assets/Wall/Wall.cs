using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int wallHealth = 100;

    private GameManager gameManager;
    private AudioManager audioManager;

    public int WallHealth { get => wallHealth; }

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void DamagingWall(int damage)
    {
        if (wallHealth > 0)
        {
            wallHealth -= damage;
        }
        else
        {
            audioManager.PlaySFX(1);
            gameManager.GameOver();
        }
    }
}
