using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace FlappyBird.Collision
{

    public abstract class BaseTrigger<T> : MonoBehaviour
    {
        [SerializeField] private GameObject m_TargetPrefab;
        protected GameObject m_Target;

        private void Start()
        {
            Assert.IsNotNull(m_TargetPrefab);            
            m_Target = GameObject.Find(m_TargetPrefab.name);
        }

        public abstract void TargetAction(T value);

        protected virtual bool HasTarget()
        {
            return m_Target != null;
        }

    }

}