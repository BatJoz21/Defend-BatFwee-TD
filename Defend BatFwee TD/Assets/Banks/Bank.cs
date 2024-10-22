using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 150;
    [SerializeField] private int currentBalance;

    public int CurrentBalance { get => currentBalance; }

    void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        if (currentBalance > 0)
        {
            currentBalance -= Mathf.Abs(amount);
        }
        else
        {
            currentBalance = 0;
        }
    }
}
