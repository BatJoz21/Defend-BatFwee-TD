using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI wallText;

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
        wallText.text = $"Wall Health = {val}";
    }
}
