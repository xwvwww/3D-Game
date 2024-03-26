using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

        _pools.Add(name, pool);
    }

    public static GameObject GetObject(string namePool, Vector3 position, Quaternion rotation)
    {
        if (!_pools.ContainsKey(namePool))
            return null;

        // GameObject obj = _pools[namePool].Objects.Find(item => item.activeSelf == false);
        GameObject obj = _pools[namePool].Objects.FirstOrDefault(x => x.activeSelf == false);

        if (obj == null) 
            return null;

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        return obj;


    }
}