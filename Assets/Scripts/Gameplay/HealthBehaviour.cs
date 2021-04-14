using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _health; 

    public float Health
    {
        get
        {
            return _health;
        }
    }

    /// <summary>
    /// Subtracts the given damage value from the health
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        //If the object health is lower or equal to 0, destroy the object
        if (_health <= 0)
            Destroy(gameObject);
    }
}
