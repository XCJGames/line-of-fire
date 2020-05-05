using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defToSelect)
    {
        defender = defToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 pos)
    {
        var coinsDisplay = FindObjectOfType<CoinsDisplay>();
        int defenderCost = defender.GetCost();
        if (coinsDisplay.HaveEnoughCoins(defenderCost))
        {
            SpawnDefender(pos);
            coinsDisplay.RemoveCoins(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 pos)
    {
        float newX = Mathf.RoundToInt(pos.x);
        float newY = Mathf.RoundToInt(pos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 pos)
    {
        Defender newDefender = Instantiate(defender, pos, transform.rotation) as Defender;
    }
}
