using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIWaypointNetwork))]
public class AIWaypointNetworkEditor : Editor
{
    private void OnSceneGUI()
    {
        AIWaypointNetwork network = target as AIWaypointNetwork;

        if (network != null)
        {
            if (network.Points == null)
                return;

            Handles.color = Color.red;
            for (int i = 0; i < network.Points.Length; i++)
            {
                if (network.Points[i] != null)
                {
                    Handles.Label(network.Points[i].position, "Waypoint " + i);
                }
            }
        }
    }




}
