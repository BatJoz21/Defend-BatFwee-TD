using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int selectedTurret = 0;
    [SerializeField] private int playerElimTarget = 10;
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject gameOverCanvas;

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
            levelCompleteCanvas.SetActive(true);
            isLevelOver = true;
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        isLevelOver = true;
    }
}
