using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsDisplay : MonoBehaviour
{
    [SerializeField] int coins = 100;
    TextMeshProUGUI coinsText;

    void Start()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        coinsText.text = coins.ToString();
    }

    public bool HaveEnoughCoins(int amount)
    {
        return amount <= coins;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateDisplay();
    }

    public void RemoveCoins(int amount)
    {
        if(coins >= amount)
        {
            coins -= amount;
            UpdateDisplay();
        }
    }
}
