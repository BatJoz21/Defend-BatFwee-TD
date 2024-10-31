using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoint = 2;
    [SerializeField] private int difficultyRamp = 2;

    private GameManager gameManager;
    private AudioManager audioManager;
    private int currentHitPoint;
    private Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoint--;
        audioManager.PlaySFX(0);
        if (currentHitPoint <= 0)
        {
            maxHitPoint += difficultyRamp;
            gameObject.SetActive(false);
            gameManager.PlayerElimTotal++;
            enemy.RewardGold();
        }
    }
}
