using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPints = 5;
    // Start is called before the first frame update
    void Start()
    {
        currentHitPints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPints--;
        if (currentHitPints <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
