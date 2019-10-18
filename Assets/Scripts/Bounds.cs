using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Utility
{

    public class Bounds : MonoBehaviour
    {
        public UnityEngine.Bounds bounds;

        private void Awake()
        {
            bounds = new UnityEngine.Bounds();
            CalculateBounds();
            Debug.Log("Bounds: " + bounds.size);
        }

        public void CalculateBounds()
        {
            bounds.size = Vector3.zero;

            Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
            foreach (var collider in colliders)
            {
                bounds.Encapsulate(collider.bounds);
            }
        }

    }

}
