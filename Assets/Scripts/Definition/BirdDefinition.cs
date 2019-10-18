using System.Runtime.Serialization;
using UnityEngine;

namespace SomeAnyBird.Definition
{
    [DataContract]
    public class BirdDefinition
    {
        #region ViewConfiguration

        [DataMember] public string PrefabName;
        public Vector3 position;
        public bool isPlayer;

        #endregion

        #region BehaviourConfiguration
//
//        [DataMember] public float Mass;
//
        [DataMember] public float flapForce;

        #endregion
    }
}