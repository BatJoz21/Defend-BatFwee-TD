using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int goldReward = 25;
    [SerializeField] private int explosionDamage = 25;

    private Bank bank;
    private Wall wall;

    void Awake()
    {
        bank = FindObjectOfType<Bank>();
        wall = FindObjectOfType<Wall>();
    }

    public void RewardGold()
    {
        if (bank == null) {  return; }
        bank.Deposit(goldReward);
    }

    public void Detonate()
    {
        wall.DamagingWall(explosionDamage);
    }
}
