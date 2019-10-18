using System;
using FlappyBird.Controller;
using SomeAnyBird.Model;
using UnityEngine;

namespace SomeAnyBird.View
{
    public class BirdView : MonoBehaviour, IView<BirdModel>
    {
        private Vector3 _startPositon;
        private Quaternion _startRotation;
        private Vector3 _startScale;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        
        private BirdModel _model;
        
        #region Unity
        private void Awake()
        {
            _startPositon = gameObject.transform.position;
            _startRotation = gameObject.transform.rotation;
            _startScale = gameObject.transform.localScale;

            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.simulated = false;

            _animator = GetComponent<Animator>();
        }

        private void OnDestroy()
        {
            Unsubscribe(_model);
        }

        #endregion

        public void Subscribe(BirdModel model)
        {
            if (model != null) Unsubscribe(model);
            
            model.OnFlap += HandleFlap;
            model.OnDispose += HandleModelDispose;
            model.OnEndGame += HandleEndGame;
            model.OnStartGame += HandleStartGame;
            _model = model;
        }

        public void Unsubscribe(BirdModel model)
        {
            model.OnDispose -= HandleModelDispose;
            model.OnFlap -= HandleFlap;
            model.OnEndGame -= HandleEndGame;
            model.OnStartGame -= HandleStartGame;
            _model = null;
        }

        public void Dead()
        {
            _animator.SetBool("Dead", true);   
        }
        
        private void HandleStartGame()
        {
            _rigidbody2D.simulated = true;
            gameObject.transform.position = _startPositon;
            gameObject.transform.rotation = _startRotation;
            gameObject.transform.localScale = _startScale;

            _animator.SetBool("Dead", false);
        }

        private void HandleEndGame()
        {
            _rigidbody2D.simulated = false;
            //_animator.SetBool("Dead", true);
        }

        private void HandleModelDispose()
        {
            Debug.Log("Bird Model dispose.");
            gameObject.SetActive(false);
            _model = null;
        }
        
        private void HandleFlap(float force)
        {
            _rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}