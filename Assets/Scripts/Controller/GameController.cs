using System;
using FlappyBird.Manager.PoolLite;
using SomeAnyBird.Controller;
using SomeAnyBird.Definition;
using SomeAnyBird.Factory;
using SomeAnyBird.Manager;
using UnityEngine;

namespace FlappyBird.Controller
{
    public class GameController : MonoBehaviour
    {
        public enum GameStatus
        {
            Initialization,
            Start,
            Game,
            End
        }

        public GameStatus Status { get; private set; }

        [SerializeField] private GameObject m_GameEndPopup;
        [SerializeField] private GameObject m_GameStartPopup;

        public event Action OnInitialization;
        public event Action OnStart;
        public event Action OnGame;
        public event Action OnEnd;
        
        private BirdController playerController;

        private void Awake()
        {
            var playerDefinition = new BirdDefinition 
            {
             PrefabName = "Bird",
             flapForce = 10.0f,
             position = new Vector3(0f, 0f,0f),
             isPlayer = false,
            };

            var playerBirdView = BirdViewFactory.CreateBirdView(playerDefinition);
            playerController = new BirdController(this, playerDefinition);
            playerController.SubscribeView(playerBirdView);            
            
            AIBirdController.InstantiateGameObject(this, new AIBirdDefinition
            {
                PrefabName = "AIBird",
                collision = false,
                color = new Color(1f, 1f, 1f, 0.5f),
                flapForce =  5f,
                interval = 0.1f,
                isPlayer = false,
                position = new Vector3(-1, 1,0), 
            });
            
            m_GameEndPopup.SetActive(false);
            m_GameStartPopup.SetActive(true);
            
            Status = GameStatus.Initialization;
            OnInitialization?.Invoke();
        }
        
        private void OnDestroy()
        {
            playerController.Dispose();
        }

        private void Update()
        {
            if (Status != GameStatus.Game && m_GameStartPopup.activeSelf && Input.GetButtonDown("Jump"))
            {
                StartGame();
            }
            else if (Input.GetButtonDown("Jump"))
            {
                PlayerInputManager.Jump();
            }
        }

        public void StartGame()
        {
            m_GameStartPopup.SetActive(false);
            m_GameEndPopup.SetActive(false);

            Status = GameStatus.Start;
            OnStart?.Invoke();

            Game();
        }
        
        public void Game()
        {
            Status = GameStatus.Game;
            OnGame?.Invoke();
        }
    
        public void End()
        {
            Status = GameStatus.End;
            m_GameEndPopup.SetActive(true);
            OnEnd?.Invoke();
        }
    }
}