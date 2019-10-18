using FlappyBird.Manager.PoolLite;
using SomeAnyBird.Model;
using Vector3 = UnityEngine.Vector3;

namespace SomeAnyBird.View
{
    public abstract class BlockView : PoolObject
    {
        public abstract void Move(float x, float y);
        public abstract void UpdateState(BlockModel model);

        public virtual bool IsVisible() => gameObject.activeSelf;
    }
}