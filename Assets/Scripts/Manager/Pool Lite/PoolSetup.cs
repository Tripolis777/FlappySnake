using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Manager.PoolLite
{

    [AddComponentMenu("Pool/PoolSetup")]
    public class PoolSetup : MonoBehaviour
    {
        #region Unity scene settings
        [SerializeField] private PoolManager.PoolPart[] pools;
        #endregion

        #region Methods

        private void OnValidate()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].name = pools[i].prefab.name;
            }
        }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            PoolManager.Initialize(pools);
        }

        #endregion
    }

}
