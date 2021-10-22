using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentbalance;
    public int CurrentBalance { get { return currentbalance; } }
    [SerializeField] TextMeshProUGUI displayBalance;

    private void Awake()
    {
        currentbalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentbalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentbalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentbalance < 0)
        {
            ReloadScene();
        }
    }

    private void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentbalance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
