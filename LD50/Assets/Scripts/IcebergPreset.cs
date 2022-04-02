using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD50
{
    [CreateAssetMenu(menuName = "Iceberg/Preset")]
    public class IcebergPreset : ScriptableObject {

        [System.Serializable]
        public struct Position {
            public int lane;
            [Range(0, 1)]
            public float offset;
        }

        public List<Position> positions;
        public float width;

    }
}
