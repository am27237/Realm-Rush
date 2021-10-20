using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPints = 5;
    Enemy enemy;
    
    void OnEnable()
    {
        currentHitPints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPints--;
        if (currentHitPints <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
