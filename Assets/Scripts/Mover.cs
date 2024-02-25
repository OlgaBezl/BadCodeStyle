using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsParent;

    public Transform CurrentWaypoint { get => _waypoints[_currentWaypointIndex]; }

    private List<Transform> _waypoints;
    private int _currentWaypointIndex;

    private void Start()
    {
        _waypoints = _waypointsParent.GetComponentsInChildren<Transform>().Where(waypoint => waypoint != _waypointsParent).ToList();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == CurrentWaypoint.position)
        {
            SelectNextWaypoint();
            transform.forward = CurrentWaypoint.position - transform.position;
        }
    }

    private void SelectNextWaypoint()
    {
        if (_currentWaypointIndex + 1 < _waypoints.Count)
        {
            _currentWaypointIndex++;
        }
        else
        {
            _currentWaypointIndex = 0;
        }
    }
}