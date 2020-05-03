using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float currentSpeed = 10f, damage = 15f;
    [SerializeField] GameObject impactVFX;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * currentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();
        GameObject impactVFXObject = Instantiate(impactVFX, transform.position, transform.rotation);
        Destroy(impactVFXObject, 1f);
        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
