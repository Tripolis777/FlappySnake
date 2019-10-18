using UnityEngine;

namespace FlappyBird.Controller {

    public class EndGameController : MonoBehaviour
    {
        [SerializeField] private GameObject m_EndGamePopup;

        public void EndGame()
        {
            Debug.Log("Game Ended");
        }

    }

}