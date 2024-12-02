using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private int cost = 75;
    
    public GameObject turretsParent;

    public bool CreateTurret(Turret turret, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            GameObject tur = Instantiate(turret.gameObject, position, Quaternion.identity);
            tur.transform.SetParent(turretsParent.transform);
            bank.Withdraw(cost);
            return true;
        }
        
        return false;
    }
}
