using System.Collections.Generic;
using FlappyBird.Controller;

namespace SomeAnyBird.Controller
{
    public class LevelController
    {
        protected GameController _gameController;

        protected float _speed;
        protected List<BlockController> _blocksList;
        
        private float _nextBlockDistance;

        public float Speed
        {
            set => _speed = value;
        }

        public int Count
        {
            get => _blocksList.Count;
        }
        
        public LevelController(GameController gameController)
        {
            _gameController = gameController;
            _gameController.OnGame += HandleGameEvent;

            _blocksList = new List<BlockController>();
            _speed = 0.0f;
        }

        protected void HandleGameEvent()
        {
            for (var i = _blocksList.Count - 1 ; i >= 0; i--)
            {
               _blocksList[i].Move(-_speed, 0.0f);
            }
        }

        protected void HandleBlockDestroy(BlockController destroyed)
        {
            RemoveBlock(destroyed);
        }
        

        public void AddBlock(BlockController block)
        {
            _blocksList.Add(block);
            block.DestroyEvent += HandleBlockDestroy;
        }

        public void RemoveBlock(BlockController block)
        {
            block.DestroyEvent -= HandleBlockDestroy;
            _blocksList.Remove(block);
        }

        public void Reset()
        {
            foreach (var block in _blocksList)
                block.DestroyEvent -= HandleBlockDestroy;
            
            _blocksList.Clear();
        }
    }
}