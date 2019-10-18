using UnityEngine;
using UnityEngine.Events;

namespace FlappyBird.Collision
{
    public class TriggerListener : MonoBehaviour
    {
        [SerializeField] private GameObject m_TriggeredObject;

        [Header("Events")]

        public UnityEvent onTriggerEnter;
        public UnityEvent onTriggerExit;

        private string m_TriggerTag = "";
        private string m_TriggerName = "";

        private void Awake()
        {
            if (onTriggerEnter == null)
                onTriggerEnter = new UnityEvent();

            if (onTriggerEnter == null)
                onTriggerExit = new UnityEvent();

            if (m_TriggeredObject != null)
            {
                m_TriggerName = m_TriggeredObject.name;
                m_TriggerTag = m_TriggeredObject.tag;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var collisionObject = collision.gameObject;
            if (collisionObject.tag == m_TriggerTag && collisionObject.name == m_TriggerName || m_TriggeredObject == null)
                onTriggerEnter.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var collisionObject = collision.gameObject;
            if (collisionObject.tag == m_TriggerTag && collisionObject.name == m_TriggerName || m_TriggeredObject == null)
                onTriggerExit.Invoke();
        }
    }

}