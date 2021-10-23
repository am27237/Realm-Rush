using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    //[SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0, 5)]float speed = 1f;
    List<Node> path = new List<Node>();
    Enemy enemy;
    GridManager gridManager;
    PathFinder pathFinder;


    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();

    }

    void FindPath()
    {
        path.Clear(); //clear whatever current objects in the list

        path = pathFinder.GetNewPath();


        //GameObject parentPath = GameObject.FindGameObjectWithTag("Path");
        ////Since we used "FindGameObjectWithTag" without the "s", we must access the child arrays to use foreach statement
        //foreach (Transform childTile in parentPath.transform)
        //{
        //    Tile waypoints = childTile.GetComponent<Tile>();
        //    if (waypoints != null)
        //    {
        //        path.Add(waypoints);
        //    }
        //}
    }

    void ReturnToStart()
    {
        //transform.position = path[0].transform.position;
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        //foreach (Tile waypoints in path)
        for (int i = 0; i < path.Count; i++)
        {
            //Smooth movement of the enemy
            Vector3 startPosition = transform.position;
            //Vector3 endPosition = waypoints.transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0;

            transform.LookAt(endPosition);  //Face at the end position

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }

    private void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
