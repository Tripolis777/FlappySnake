namespace SomeAnyBird.View
{
    public interface IView<T>
    {
        void Subscribe(T model);
        void Unsubscribe(T model);
    }
}