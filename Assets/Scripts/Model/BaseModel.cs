using System;

namespace SomeAnyBird.Model
{
    public class ModelAction<T>
    {
        private T _model;
        public event Action<T> OnChangeEvent;
        
        public ModelAction(T model)
        {
            _model = model;
        }
    }
}