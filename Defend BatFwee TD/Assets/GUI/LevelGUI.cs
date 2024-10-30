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
    [SerializeField] private GameObject optionCanvas;

    private GameManager gameManager;
    private Bank bank;
    private Wall wall;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        bank = FindObjectOfType<Bank>();
        wall = FindObjectOfType<Wall>();
    }

    void Update()
    {
        ShowGoldUI(bank.CurrentBalance);
        ShowWallUI(wall.WallHealth);
        ShowElimUI(gameManager.PlayerElimTotal);
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

    public void OpenOption()
    {
        optionCanvas.SetActive(true);
        gameManager.isOpeningOption = true;
    }
}
