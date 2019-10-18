using FlappyBird.Manager.PoolLite;
using SomeAnyBird.Definition;
using SomeAnyBird.View;

namespace SomeAnyBird.Factory
{
    public static class BlockViewFactory
    {
        public static BlockView CreateBlockView(BlockDefinition definition)
        {
            var gameObject = PoolManager.GetObject(definition.prefabName);
            return gameObject.GetComponent<BlockView>();
        }
        
    }
}