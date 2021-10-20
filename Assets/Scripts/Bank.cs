using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentbalance;
    public int CurrentBalance { get { return currentbalance; } }

    private void Awake()
    {
        currentbalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentbalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentbalance -= Mathf.Abs(amount);

        if (currentbalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
