using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGUI : MonoBehaviour
{
    [SerializeField] private OptionGUI optionsCanvas;

    void Awake()
    {
        optionsCanvas = FindObjectOfType<OptionGUI>();
    }

    public void NextScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void OpenOption()
    {
        optionsCanvas.OpenOption();
    }
}
