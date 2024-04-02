using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaypointNetwork : MonoBehaviour
{
    private Transform[] _points;
    public Transform[] Points => _points;
    public Transform this[int i]
    {
        get { return _points[i]; }
        set { _points[i] = value;}
    }

    private void Awake()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    public Transform GetPoint()
    {
        int index = Random.Range(0, _points.Length);
        return _points[index];
    }



}
