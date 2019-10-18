using System;
using SomeAnyBird.Controller;
using SomeAnyBird.Definition;
using SomeAnyBird.Manager;
using SomeAnyBird.Model;
using SomeAnyBird.View;

namespace FlappyBird.Controller
{
    // Player Bird Controller class
    public class BirdController : GameObjectController<BirdModel>, IDisposable
    {
        protected readonly GameController _controller;

        public BirdController(GameController controller, BirdDefinition definition)
        {
            Model = new BirdModel(definition);
            PlayerInputManager.OnJump += HandleInputJump;

            _controller = controller;
            _controller.OnStart += HandleGameStart;
            _controller.OnEnd += HandleGameEnd;
        }

        public void Dispose()
        {
            PlayerInputManager.OnJump -= HandleInputJump;

            _controller.OnStart -= HandleGameStart;
            _controller.OnEnd -= HandleGameEnd;
        }

        public void SetFlapForce(float flapForce)
        {
            Model.flapForce = flapForce;
        }

        public void SubscribeView(IView<BirdModel> view)
        {
            view.Subscribe(Model);
        }
        
        private void HandleGameStart()
        {
            Model.StartGame();
        }

        private void HandleGameEnd()
        {
            Model.EndGame();
        }

        private void HandleInputJump()
        {
            Model.Flap();
        }
    }
}