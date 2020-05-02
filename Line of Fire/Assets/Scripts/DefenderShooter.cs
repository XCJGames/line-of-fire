using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    public void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
