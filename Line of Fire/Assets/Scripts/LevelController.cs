using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteCanvas, lostLevelCanvas;
    int attackersAlive;
    bool timerFinished = false;
    int totalAttackers, totalDefenders, coinsSpent;

    public int GetTotalAttackers()
    {
        return totalAttackers;
    }

    public int GetTotalDefenders()
    {
        return totalDefenders;
    }

    public int GetCoinsSpent()
    {
        return coinsSpent;
    }


    private void Start()
    {
        totalAttackers = 0;
        totalDefenders = 0;
        coinsSpent = 0;
        levelCompleteCanvas.SetActive(false);
        lostLevelCanvas.SetActive(false);
    }

    internal void LostLevel()
    {
        if (!levelCompleteCanvas.activeSelf)
        {
            lostLevelCanvas.SetActive(true);
        }
    }

    public void DefenderSpawned()
    {
        totalDefenders++;
    }

    public void AttackerSpawned()
    {
        attackersAlive++;
        totalAttackers++;
    }

    public void AttackerEscaped()
    {
        totalAttackers--;
    }

    public void AttackerDefeated()
    {
        attackersAlive--;
        if(attackersAlive == 0 && timerFinished)
        {
            if(CheckFinishedSpawners())
                LevelComplete();
        }
    }

    private bool CheckFinishedSpawners()
    {
        bool allFinished = true;
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            if (!spawner.GetFinishedSpawning())
            {
                allFinished = false;
                break;
            }
        }

        return allFinished;
    }

    private void LevelComplete()
    {
        if (!lostLevelCanvas.activeSelf)
        {
            levelCompleteCanvas.SetActive(true);
            var totalAttackersGO = GameObject.FindGameObjectWithTag("totalAttackersNumber");
            var totalDefendersGO = GameObject.FindGameObjectWithTag("totalDefendersNumber");
            var totalTimeGO = GameObject.FindGameObjectWithTag("totalTimeNumber");
            var coinsSpentGO = GameObject.FindGameObjectWithTag("coinsSpentNumber");

            totalAttackersGO.GetComponent<TextMeshProUGUI>().text = totalAttackers.ToString();
            totalDefendersGO.GetComponent<TextMeshProUGUI>().text = totalDefenders.ToString();
            totalTimeGO.GetComponent<TextMeshProUGUI>().text = 
                Math.Round(Time.timeSinceLevelLoad, 2).ToString() + " seconds";
            coinsSpentGO.GetComponent<TextMeshProUGUI>().text = coinsSpent.ToString();
        }
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.SetSpawn(false);
        }
    }

    public void SetTimerToFinished()
    {
        timerFinished = true;
        StopSpawners();
    }

    public void AddCoinsSpent(int amount)
    {
        coinsSpent += amount;
    }
}
