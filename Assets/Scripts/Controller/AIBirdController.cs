using System;
using FlappyBird.Controller;
using SomeAnyBird.Definition;
using SomeAnyBird.Factory;
using SomeAnyBird.Model;
using SomeAnyBird.View;
using UnityEngine;

namespace SomeAnyBird.Controller
{
    public class AIBirdController : MonoBehaviour
    {
        private GameController _gameController;
        private BirdModel _model;
        private BirdView _view;

        private Vector3 _startPosition;
        private float _interval;

        private float _waitInterval;

        #region Unity

        private void FixedUpdate()
        {
            _waitInterval -= Time.fixedDeltaTime;
            if (_gameController.Status == GameController.GameStatus.Game && _waitInterval <= 0.0f)
            {
                _model.flapForce = GetForce();
                _model.Flap();
                _waitInterval = _interval;
            }
        }

        private void OnDestroy()
        {
            _gameController.OnStart -= HandleStartGame;
            _gameController.OnEnd -= HandleEndGame;
            _view.Unsubscribe(_model);
        }

        #endregion
        
        public static void InstantiateGameObject(GameController controller, AIBirdDefinition definition)
        {
            var view = BirdViewFactory.CreateBirdView(definition);
            var aiController = view.gameObject.AddComponent<AIBirdController>();
            aiController.Initialize(controller, definition, view);
        }

        private void Initialize(GameController controller, AIBirdDefinition definition, BirdView view)
        {
            _model = new BirdModel(definition);
            InitializeView(definition, view);

            _interval = definition.interval;
            _waitInterval = 0.0f;
            
            _view.Subscribe(_model);
            _gameController = controller;
            
            _gameController.OnStart += HandleStartGame;
            _gameController.OnEnd += HandleEndGame;
        }
        
        private void InitializeView(AIBirdDefinition definition, BirdView view)
        {
            _view = view;
            
            var spriteRender = _view.GetComponent<SpriteRenderer>();
            spriteRender.color = definition.color;
            
            _startPosition = definition.position;
            ResetPosition();

            //var collider = _view.GetComponent<Collider>();
            //collider.enabled = definition.collision;
        }
        
        private void ResetPosition()
        {
            _view.transform.position = _startPosition;
        }
        
        private void HandleStartGame()
        {
            _model.StartGame();
            ResetPosition();
        }


        private void HandleEndGame()
        {
            _model.EndGame();
        }

        private float GetForce()
        {
            var gravity = Physics.gravity.magnitude;
            var distance = _startPosition.y - _view.transform.position.y;
            
            return distance > 0 ? Mathf.Sqrt(0.5f * gravity * Mathf.Pow(distance, 2)) : 0;
        }
    }
}