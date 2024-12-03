using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI elimText;
    [SerializeField] private Slider wallHealthBar;
    [SerializeField] private OptionGUI optionCanvas;
    [SerializeField] private GameObject[] turretActiveSymbols;

    private LevelManager levelManager;
    private Bank bank;
    private Wall wall;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        optionCanvas = FindObjectOfType<OptionGUI>();
        bank = FindObjectOfType<Bank>();
        wall = FindObjectOfType<Wall>();
    }

    void Update()
    {
        ShowGoldUI(bank.CurrentBalance);
        ShowWallUI(wall.WallHealth);
        ShowElimUI(levelManager.PlayerElimTotal);
        ShowSelectedTurret(levelManager.SelectedTurret);
    }

    private void ShowGoldUI(int val)
    {
        goldText.text = $"Gold = {val}";
    }

    private void ShowWallUI(int val)
    {
        float health = val / 100f;
        wallHealthBar.value = health;
    }

    private void ShowElimUI(int val)
    {
        elimText.text = $"Elimination\n{val}";
    }

    private void ShowSelectedTurret(int val)
    {
        switch (val)
        {
            case 0:
                turretActiveSymbols[0].SetActive(true);
                turretActiveSymbols[1].SetActive(false);
                turretActiveSymbols[2].SetActive(false);
                break;
            case 1:
                turretActiveSymbols[0].SetActive(false);
                turretActiveSymbols[1].SetActive(true);
                turretActiveSymbols[2].SetActive(false);
                break;
            case 2:
                turretActiveSymbols[0].SetActive(false);
                turretActiveSymbols[1].SetActive(false);
                turretActiveSymbols[2].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void OpenOption()
    {
        optionCanvas.OpenOption();
    }
}
