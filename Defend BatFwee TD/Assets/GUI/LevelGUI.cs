using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Slider wallHealthBar;
    [SerializeField] private GameObject optionCanvas;

    private Bank bank;
    private Wall wall;

    void Awake()
    {
        bank = FindObjectOfType<Bank>();
        wall = FindObjectOfType<Wall>();
    }

    void Update()
    {
        ShowGoldUI(bank.CurrentBalance);
        ShowWallUI(wall.WallHealth);
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

    public void OpenOption()
    {
        optionCanvas.SetActive(true);
    }
}
