using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Manager.PoolLite
{

    public static class PoolManager
    {
        private static PoolPart[] pools;
        private static GameObject objectsParent;

        [System.Serializable]
        public struct PoolPart
        {
            public string name;
            public PoolObject prefab;
            public int count;
            public ObjectPooling ferula;
        }

        public static void Initialize(PoolPart[] newPools)
        {
            pools = newPools;
            objectsParent = new GameObject();
            objectsParent.name = "Pool";

            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].prefab != null)
                {
                    pools[i].ferula = new ObjectPooling();
                    pools[i].ferula.Initialize(pools[i].count, pools[i].prefab, objectsParent.transform);
                }
            }
        }

        public static GameObject GetObject(string name, Vector3 position, Quaternion rotation)
        {
            var result = GetObject(name);
            if (result == null) return result;
            
            result.transform.position = position;
            result.transform.rotation = rotation;

            return result;
        }

        public static GameObject GetObject(string name)
        {
            GameObject result = null;
            if (pools == null) return result;
            for (var i = 0; i < pools.Length; i++)
            {
                if (string.Compare(pools[i].name, name) != 0) continue;
                result = pools[i].ferula.GetObject().gameObject;
                result.SetActive(true);
                        
                return result;
            }
            return result;
        }
    }

}