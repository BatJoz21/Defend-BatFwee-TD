using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private int wallHealth = 100;

    public int WallHealth { get => wallHealth; }

    public void DamagingWall(int damage)
    {
        if (wallHealth > 0)
        {
            wallHealth -= damage;
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        //
    }
}
