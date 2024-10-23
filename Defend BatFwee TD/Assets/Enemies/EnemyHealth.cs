using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoint = 5;
    [SerializeField] private int difficultyRamp = 0;

    private int currentHitPoint;
    private Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoint = maxHitPoint + difficultyRamp;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoint--;
        if (currentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
