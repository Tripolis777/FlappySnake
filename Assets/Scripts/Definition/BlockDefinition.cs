using System.Runtime.Serialization;

namespace SomeAnyBird.Definition 
{
    [DataContract]
    public class BlockDefinition
    {
        #region PassConfiguration
        
        [DataMember]
        public float PassMaxDistance;
        [DataMember]
        public float PassMinDistance;

        #endregion

        #region PositionConfiguration
        
        [DataMember]
        public float PositionMaxDistance;
        [DataMember]
        public float PositionMinDistance;

        #endregion

        #region ViewConfiguration

        [DataMember] 
        public string prefabName;

        #endregion
    }
}