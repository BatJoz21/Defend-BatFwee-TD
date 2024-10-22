using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField, Range(0, 5f)] private float speedValue = 1f;

    private Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine("FollowPath");
    }

    private void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }

        /*
        GameObject waypointParent = GameObject.FindGameObjectWithTag("Path");
        Transform[] waypointChildren = waypointParent.GetComponentsInChildren<Transform>();

        foreach (Transform waypoin in waypointChildren)
        {
            path.Add(waypoin.gameObject.GetComponent<Waypoint>());
        }
        */
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    private IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speedValue;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        enemy.Detonate();
        gameObject.SetActive(false);
    }
}
