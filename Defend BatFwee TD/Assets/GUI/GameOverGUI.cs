using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverGUI : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelButton;

    private int currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        int maxSceneIndex = SceneManager.sceneCountInBuildSettings;
        if(currentScene == maxSceneIndex)
        {
            nextLevelButton.SetActive(false);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
