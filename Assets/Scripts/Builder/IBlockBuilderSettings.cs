using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Builder
{

    public interface IBlockBuilderSettings
    {
        GameObject[] presets { get; }
        float maxDistance { get;  }
        int count { get;  }

        Transform blockSpawn { get;  set; }
        Transform parent { get; set; }
    }

}