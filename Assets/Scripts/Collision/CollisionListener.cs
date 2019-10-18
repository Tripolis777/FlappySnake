using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FlappyBird.Collision
{
    public class CollisionListener : MonoBehaviour
    {
        [SerializeField] LayerMask m_WathIsDetect = 0;

        [Header("Event")]

        public UnityEvent onLayerCollisionDetect;

        private void Awake()
        {
            if (onLayerCollisionDetect == null)
                onLayerCollisionDetect = new UnityEvent();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (((1 << collision.gameObject.layer) & m_WathIsDetect) > 0)
            {
                onLayerCollisionDetect.Invoke();
            }
        }

    }
}
