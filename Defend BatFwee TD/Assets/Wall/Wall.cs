using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int wallHealth = 100;

    private GameManager gameManager;

    public int WallHealth { get => wallHealth; }

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void DamagingWall(int damage)
    {
        if (wallHealth > 0)
        {
            wallHealth -= damage;
        }
        else
        {
            gameManager.GameOver();
        }
    }
}
