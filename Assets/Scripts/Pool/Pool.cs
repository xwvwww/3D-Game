using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public string name;
    public int size;
    public bool resize;
    public List<GameObject> Objects;
    public Transform parent;

    public Pool(string name, int size, bool resize)
    {
        this.name = name;
        this.size = size;
        this.resize = resize;
        Objects = new List<GameObject>();
    }



}
