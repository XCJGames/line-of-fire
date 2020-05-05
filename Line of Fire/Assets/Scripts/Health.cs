using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (GetComponent<Animator>())
            {
                
                GetComponent<Animator>().SetTrigger("isDead");
                Destroy(GetComponent<BoxCollider2D>());
            }
            else
            {
                DestroySelf();
            }
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
