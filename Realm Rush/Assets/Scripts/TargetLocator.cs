using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] float range = 25;
    [SerializeField] ParticleSystem arrowFire;
    [SerializeField] Transform weapon;
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        EnemyScript[] enemies = FindObjectsOfType<EnemyScript>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (EnemyScript enemyScript in enemies)
        {
            float dis = Vector3.Distance(transform.position, enemyScript.transform.position);
            if (dis < maxDistance)
            {
                closestTarget = enemyScript.transform;
                maxDistance = dis;
            }   
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);
        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }
    void Attack(bool isActive)
    {
        var emissionModule = arrowFire.emission;
        emissionModule.enabled = isActive;
    }
}
