using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Player's Status")]
    [SerializeField] private int selectedTurret = 0;
    [SerializeField] private int playerElimTarget = 10;

    [Header("Canvas")]
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject gameOverCanvas;

    [Header("Other")]
    [SerializeField] private GameObject[] levelComponents;

    private int playerElimTotal = 0;

    public bool isOpeningOption = false;
    public bool isLevelOver = false;

    public int SelectedTurret { get => selectedTurret; }
    public int PlayerElimTotal { get => playerElimTotal; set => playerElimTotal = value; }

    void Update()
    {
        Win();
    }

    public void SetTurret(int val) { selectedTurret = val; }

    public void Win()
    {
        if (playerElimTotal == playerElimTarget)
        {
            DestroyLevelComponents();
            levelCompleteCanvas.SetActive(true);
            isLevelOver = true;
        }
    }

    public void GameOver()
    {
        DestroyLevelComponents();
        gameOverCanvas.SetActive(true);
        isLevelOver = true;
    }

    private void DestroyLevelComponents()
    {
        foreach (GameObject component in levelComponents)
        {
            component.SetActive(false);
        }
    }
}
