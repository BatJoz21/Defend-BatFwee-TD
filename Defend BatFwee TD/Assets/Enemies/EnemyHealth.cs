using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoint = 2;
    [SerializeField] private int difficultyRamp = 2;

    private LevelManager levelManager;
    private AudioManager audioManager;
    private int currentHitPoint;
    private Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }

    void Update()
    {
        SetUpAudioManager();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoint--;
        if (audioManager != null)
        {
            audioManager.PlaySFX(0);
        }
        if (currentHitPoint <= 0)
        {
            maxHitPoint += difficultyRamp;
            gameObject.SetActive(false);
            levelManager.PlayerElimTotal++;
            enemy.RewardGold();
        }
    }

    private void SetUpAudioManager()
    {
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }
}
