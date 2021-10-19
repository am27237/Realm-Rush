using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoints> path = new List<Waypoints>();
    [SerializeField] float waitSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    IEnumerator PrintWaypointName()
    {
        foreach (Waypoints waypoints in path)
        {
            transform.position = waypoints.transform.position;
            yield return new WaitForSeconds(waitSpeed);
            //test
        }
    }
}
