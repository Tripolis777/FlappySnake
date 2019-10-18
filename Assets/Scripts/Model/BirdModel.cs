using System;
using FlappyBird.Controller;
using SomeAnyBird.Definition;

namespace SomeAnyBird.Model
{
    public class BirdModel : IDisposable
    {
        public event Action<float> OnFlap;
        public event Action OnDispose;
        public event Action OnStartGame;
        public event Action OnEndGame;

        public float flapForce;

        public BirdModel(BirdDefinition definition)
        {
            flapForce = definition.flapForce;
        }

        public void Flap()
        {
            OnFlap?.Invoke(flapForce);
        }

        public void Dispose()
        {
            OnDispose?.Invoke();
            OnFlap = null;
            OnDispose = null;
            OnStartGame = null;
            OnEndGame = null;
        }

        public void StartGame()
        {
            OnStartGame?.Invoke();
        }

        public void EndGame()
        {
            OnEndGame?.Invoke();
        }
    }
}