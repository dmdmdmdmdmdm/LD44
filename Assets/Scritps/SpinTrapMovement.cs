using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTrapMovement : MonoBehaviour
{

    [SerializeField]
    private Vector3[] waypoints;
    [SerializeField]
    private float speed = 5f;

    private int noWaypoints;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Length > 0)
        {
            noWaypoints = waypoints.Length;
            transform.position = waypoints[count];
        } else
        {
            noWaypoints = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (noWaypoints > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[count], speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypoints[count]) <= 0.05f)
            {
                count++;
            }
            if (count >= noWaypoints)
            {
                count = 0;
            }
        }
    }
}
