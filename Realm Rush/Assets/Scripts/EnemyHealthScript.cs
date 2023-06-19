using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] int totalHitResistance = 5;
    [Tooltip("Adds amount to totalHitResistance when enemy dies")] 
    [SerializeField] int difficultyRamp = 1;

    private int currentHitCount = 0;

    EnemyScript enemyScript;

    private void OnEnable()
    {
        currentHitCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = FindObjectOfType<EnemyScript>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitCount++;
        if (currentHitCount >= totalHitResistance)
        {
            gameObject.SetActive(false);
            totalHitResistance += difficultyRamp;
            enemyScript.RewardGold();
        }
    }
}
