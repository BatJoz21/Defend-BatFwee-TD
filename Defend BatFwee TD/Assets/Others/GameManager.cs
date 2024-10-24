using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int selectedTurret = 0;

    public int SelectedTurret { get => selectedTurret; }

    public void SetTurret(int val) { selectedTurret = val; }

    public void GameOver()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
