using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputBehaviour))]
public class MovementBehaviour : MonoBehaviour {
    [SerializeField]
    float moveSpeed = 6;
    [SerializeField]
    PathCreator pathCreator;
    [SerializeField]
    float spacing = .1f;
    [SerializeField]
    float resolution = 1;

    Vector2[] waypoints;
    int currWaypointIndex = 0;

    InputBehaviour input;

    private void Start()
    {
        input = GetComponent<InputBehaviour>();
        waypoints = pathCreator.path.CalculateEvenlySpacedPoints(spacing, resolution);
       /* foreach (Vector2 p in waypoints)
        {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            g.transform.position = p;
            g.transform.localScale = Vector3.one * spacing * .5f;
        }*/
    }

    private void Update()
    {
        Vector2 target = SetTarget();
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed*Mathf.Abs(input.Horizontal)*Time.deltaTime);
        CheckIfWaypointInRange();
    }

    private Vector2 SetTarget()
    {
        if (input.Horizontal<0)
        {
            return waypoints[currWaypointIndex];
        }
        else if (input.Horizontal>0)
        {
                return waypoints[currWaypointIndex + 1];
        }
        else
        {
            return transform.position;
        }
    }

    private void CheckIfWaypointInRange()
    {
        if (input.Horizontal<0 && Vector2.Distance(waypoints[currWaypointIndex],transform.position)<.05f)
        {
            if (currWaypointIndex != 0)
            {
                currWaypointIndex--;
            }
        }
        else if (input.Horizontal>0 && Vector2.Distance(waypoints[currWaypointIndex+1], transform.position) < .05f)
        {
            if (currWaypointIndex != waypoints.Length-2)
            {
                currWaypointIndex++;
            }
        }
    }
}
