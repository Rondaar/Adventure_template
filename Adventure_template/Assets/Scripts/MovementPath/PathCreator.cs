using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{

    [HideInInspector]
    public MovementPath path;

    public void CreatePath()
    {
        path = new MovementPath(transform.position);
    }
}