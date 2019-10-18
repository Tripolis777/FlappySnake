using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using FlappyBird.Controller;
using SomeAnyBird.Controller;
using SomeAnyBird.Definition;

namespace FlappyBird.Builder
{
    public class BlockBuilder : MonoBehaviour
    {

        [SerializeField] private GameController m_GameController;

        [SerializeField] private GameObject[] m_Presets;
        [SerializeField] private float m_maxDistance = 3f;
        [SerializeField] public float m_MinDistance = 1f;

        [SerializeField] private GameObject m_BlockSpawn;
        [SerializeField] private Transform m_DedstroyZone;
        [Range(1f, 10f)]
        [SerializeField] private float speed = 1f;

        private Transform m_Parent;

        private float nextBlockDistance;

        private List<BlockController> _blocks;
        
        #region Unity

        private void Awake()
        {
            m_Parent = gameObject.transform;
            _blocks = new List<BlockController>();
        }

        private void Start()
        {
            m_GameController.OnStart += HandleGameStart;
        }

        private void Update()
        {
            if (m_GameController.Status != GameController.GameStatus.Game) return;
            
            if (_blocks.Count == 0 || Mathf.Abs(_blocks.Last().Model.View.transform.position.x - m_BlockSpawn.transform.position.x) > nextBlockDistance )
            {
                SpawnRandomBlock();
            }

            for (var i = _blocks.Count - 1 ; i >= 0; i--)
            {
                var blockController = _blocks[i];
                var blockView = blockController.Model.View;
                blockController.Move(-speed, 0);

                if (!(blockView.transform.position.x < m_DedstroyZone.position.x)) continue;
                _blocks.Remove(blockController);
                blockController.Destroy();
            }
        }
        
        #endregion

        private void SpawnRandomBlock()
        {
            nextBlockDistance = Random.Range(m_MinDistance, m_maxDistance);
            SpawnBlock(Random.Range(0, m_Presets.Length));
        }

        private void SpawnBlock(int index)
        {
            var blockPreset = m_Presets[index];
            var definition = new BlockDefinition
            {
                prefabName = blockPreset.name,
                PassMaxDistance = 4.0f,
                PassMinDistance = 2.0f,
                PositionMinDistance = 0.0f,
                PositionMaxDistance = 3.0f
            };

            var blockController = new BlockController(definition);
            var blockView = blockController.Model.View;
            blockView.transform.position = m_BlockSpawn.transform.position;
            blockView.transform.SetParent(m_Parent);
            
            if (blockController != null)
            {
                blockController.SetRandom(); 
            }
            
            _blocks.Add(blockController);
        }

        private void HandleGameStart()
        {
            for (var i = _blocks.Count - 1;  i >= 0; i--)
            {
                var blockController = _blocks[i];
                _blocks.RemoveAt(i);
                blockController.Destroy();
            }
        }
        
    }

}
