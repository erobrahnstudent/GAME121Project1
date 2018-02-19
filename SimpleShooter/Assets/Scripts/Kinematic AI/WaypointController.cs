using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaypointController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> waypoints;
    public KinematicCore core;
    [SerializeField]
    int currentWaypoint;

    bool isActive = true;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            waypoints.Add(transform.GetChild(i).gameObject);
            currentWaypoint = 0;
            core.Seek(waypoints[currentWaypoint].transform.position, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (core.SeekTargetSet == false && isActive)
        {
            WaypointContinue();
        }
    }

    public void WaypointContinue()
    {
        if (currentWaypoint >= waypoints.Count - 1) { currentWaypoint = 0; }
        else
        {
            currentWaypoint++;
        }
        core.Seek(waypoints[currentWaypoint].transform.position, false);
    }

    public void ToggleActive()
    {
        if (isActive) { isActive = false; }
        else { isActive = true; }
    }
}
