using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float currentSpeed = 10f, damage = 15f;
    [SerializeField] GameObject impactVFX;
    GameObject impactVFXParent;

    const string IMPACT_VFX_PARENT_NAME = "Impact VFXs";

    private void Start()
    {
        CreateImpactVFXParent();
    }

    private void CreateImpactVFXParent()
    {
        impactVFXParent = GameObject.Find(IMPACT_VFX_PARENT_NAME);
        if (!impactVFXParent)
        {
            impactVFXParent = new GameObject(IMPACT_VFX_PARENT_NAME);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * currentSpeed);
        if (transform.position.x > 12) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();
        if(attacker && health)
        {
            GameObject impactVFXObject = Instantiate(impactVFX, transform.position, transform.rotation);
            impactVFXObject.transform.parent = impactVFXParent.transform;
            Destroy(impactVFXObject, 1f);
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
