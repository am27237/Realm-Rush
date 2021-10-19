using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoints> path = new List<Waypoints>();
    [SerializeField] [Range(0, 5)]float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    IEnumerator PrintWaypointName()
    {
        foreach (Waypoints waypoints in path)
        {
            //Smooth movement of the enemy
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoints.transform.position;
            float travelPercent = 0;

            transform.LookAt(endPosition);  //Face at the end position

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
