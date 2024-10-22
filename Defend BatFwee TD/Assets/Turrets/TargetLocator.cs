using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private float range = 15f;
    [SerializeField] private ParticleSystem[] turretBullets;

    private Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        weapon.LookAt(target);

        if (targetDistance <= range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool val)
    {
        foreach (ParticleSystem bullet in turretBullets)
        {
            var bulletEmission = bullet.GetComponent<ParticleSystem>().emission;
            bulletEmission.enabled = val;
        }
    }
}
