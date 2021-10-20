using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{

    [SerializeField] int cost = 75;

    public bool CreateTower(Towers towers, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        
        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(towers, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
