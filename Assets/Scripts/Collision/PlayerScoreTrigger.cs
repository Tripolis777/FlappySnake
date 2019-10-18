using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Collision
{

    public class PlayerScoreTrigger : BaseTrigger<int>
    {
        [SerializeField] private AudioClip audioClip;

        private PlayerScore _playerScoreController;
        private GameObject _gameController;

        private void Awake()
        {
            _gameController = GameObject.Find("GameController");
            _playerScoreController = _gameController?.GetComponent<PlayerScore>();
        }
        
        public override void TargetAction(int value)
        {
            if (!HasTarget()) return;
            
            Debug.Log("Target Action!!!");
            
            _playerScoreController?.ChangeScore(value);
            var audioSource = m_Target.GetComponent<AudioSource>();
            if (audioSource != null && audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }

}
