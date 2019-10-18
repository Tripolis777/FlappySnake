using System;
using SomeAnyBird.Data;
using SomeAnyBird.Definition;
using SomeAnyBird.Factory;
using SomeAnyBird.Model;

namespace SomeAnyBird.Controller
{
    public class BlockController
    { 
        protected BlockModel _model;

        public event Action<BlockController> DestroyEvent;
        
        public BlockController(BlockDefinition definition)
        {
            _model = new BlockModel(BlockViewFactory.CreateBlockView(definition));
            _model.Pass = new DistanceRange(definition.PassMinDistance, definition.PassMaxDistance, 0.0f);
            _model.Position = new DistanceRange(definition.PositionMinDistance, definition.PositionMaxDistance, 0.0f);
        }
        
        public BlockModel Model => _model;

        public void Move(float x, float y)
        {
            _model.Move(x, y);
        }
        
        public void SetPass(float proportion)
        {
            _model.Pass.Proportion = proportion;
        }

        public void SetPosition(float proportion)
        {
            _model.Position.Proportion = proportion;
        }

        public void Apply()
        {
            _model.Apply();
        }
        
        public void SetRandom()
        {
            SetPass(DistanceRange.GetRandomProportion());
            SetPosition(DistanceRange.GetRandomProportion());
            Apply();
        }

        public void Destroy()
        {
            _model.Destroy();
            DestroyEvent?.Invoke(this);
        }
        
    }
    
}