using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

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

            
            for (int i = 0; i < network.Points.Length; i++)
            {
                if (network.Points[i] != null)
                {
                    Handles.Label(network.Points[i].position, "Waypoint " + i);
                }
            }

            Vector3[] p = new Vector3[network.Points.Length + 1];
            for (int i = 0; i <= network.Points.Length; i++)
            {
                int index = i != network.Points.Length ? i : 0;
                if (network.Points[index] != null)
                {
                    p[i] = network.Points[index].position;
                }
                else
                {
                    p[i] = new Vector3(Mathf.Infinity,
                                           Mathf.Infinity,
                                           Mathf.Infinity);
                }
            }

            Handles.color = Color.red;
            Handles.DrawPolyLine(p);
        }
    }




}
