using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultBot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.GetComponent<Obstacle>())
            {
                GetComponent<Animator>().SetTrigger("jump");
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
        }
    }
}
