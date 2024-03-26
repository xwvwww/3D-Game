using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private static Dictionary<string, Pool> _pools;

    static PoolManager()
    {
        _pools = new Dictionary<string, Pool>();
    }

    public static void CreatePool(string name, int count, GameObject prefab, bool resize)
    {
        if (_pools.ContainsKey(name))
            return;

        Pool pool = new Pool(name, count, resize);
        pool.parent = new GameObject("Pool" + name).transform;

        for (int i = 0; i < count; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.name = name + i;
            obj.transform.parent = pool.parent;
            obj.SetActive(false);

            pool.Objects.Add(obj);
        }
    }
}