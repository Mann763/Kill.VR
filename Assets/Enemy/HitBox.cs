using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Enemy_Health health;


    public void OnRaycastHit(SimpleShoot weapon, Vector3 direction)
    {
        health.TakeDamage(weapon.GiveDamage, direction);
    }
    
}
