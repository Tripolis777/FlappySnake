using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Manager.PoolLite
{

    [AddComponentMenu("Pool/ObjectPooling")]
    public class ObjectPooling 
    {
        #region Data
        List<PoolObject> objects;
        Transform objectsParent;
        #endregion

        void AddObject(PoolObject sample, Transform object_parent)
        {
            GameObject temp = GameObject.Instantiate(sample.gameObject);
            temp.name = sample.name;
            temp.transform.SetParent(objectsParent);
            objects.Add(temp.GetComponent<PoolObject>());
            if (temp.GetComponent<Animator>())
            {
                temp.GetComponent<Animator>().StartPlayback();
            }
            temp.SetActive(false);
        }

        public void Initialize(int count, PoolObject sample, Transform objects_parent)
        {
            objects = new List<PoolObject>();
            objectsParent = objects_parent;

            for (int i = 0; i < count; i++)
            {
                AddObject(sample, objects_parent);
            }
        }

        public PoolObject GetObject()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].gameObject.activeInHierarchy == false)
                {
                    return objects[i];
                }
            }
            AddObject(objects[0], objectsParent);
            return objects[objects.Count - 1];
        }
    }

}
