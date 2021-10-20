using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoints> path = new List<Waypoints>();
    [SerializeField] [Range(0, 5)]float speed = 1f;
    Enemy enemy;
    
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear(); //clear whatever current objects in the list
                      
        //Add all path arrays in the path list
        GameObject[] waypoint = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypointVar in waypoint)
        {
            path.Add(waypointVar.GetComponent<Waypoints>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
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

        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
