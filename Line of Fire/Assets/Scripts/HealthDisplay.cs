using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int health = 5;
    TextMeshProUGUI healthText;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void RemoveHealth()
    {
        health--;
        if (health > 0)
        {
            UpdateDisplay();
        }
        else
        {
            FindObjectOfType<LevelLoader>().LoadLoseScene();
        }
    }
}
