﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorPath : MonoBehaviour {

    public Color rayColor = Color.white;
    public List<Transform> path_objs = new List<Transform>();
    public int baseLayer;
    Transform[] array;

    void Start()
    {
        array = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        foreach (Transform path_obj in array)
        {
            if (path_obj != this.transform)
            {
                path_objs.Add(path_obj);
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        array = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        foreach(Transform path_obj in array)
        {
            if (path_obj != this.transform)
            {
                path_objs.Add(path_obj);
            }
        }

        for (int i = 0; i < path_objs.Count; i++)
        {
            Vector3 position = path_objs[i].position;
            if (i > 0)
            {
                Vector3 previous = path_objs[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
    }
}
