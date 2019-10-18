namespace SomeAnyBird.Controller
{
    public abstract class GameObjectController<T>
    {
        private T _model;
        
        public T Model
        {
            get => _model;
            protected set { _model = value; }
        }
    }
}