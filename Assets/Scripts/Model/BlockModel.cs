using SomeAnyBird.Data;
using SomeAnyBird.View;

namespace SomeAnyBird.Model
{
    public class BlockModel
    {
        protected BlockView _view;
        public DistanceRange Pass;
        public DistanceRange Position;
        
        public BlockView View => _view;

        public bool Active
        {
            get => _view.IsVisible();
        }
        
        public BlockModel(BlockView view)
        {
            _view = view;
        }

        public void Move(float x, float y)
        {
            _view.Move(x, y);
        }

        public void Destroy()
        {
            _view.ReturnToPool();
        }

        public void Apply()
        {
            _view.UpdateState(this);
        }
        
    }
}
