using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Collision {

    public class BoosterTrigger : BaseTrigger<float>
    {
        public override void TargetAction(float value)
        {
            if (!HasTarget()) return;
            m_Target.transform.localScale = m_Target.transform.localScale * value;
        }

    }

}
