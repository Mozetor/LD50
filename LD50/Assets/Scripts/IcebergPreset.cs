using System.Collections.Generic;
using UnityEngine;

namespace LD50 {
    [CreateAssetMenu(menuName = "Iceberg/Preset")]
    public class IcebergPreset : ScriptableObject {

        public enum ElementType { 
            [InspectorName("Iceberg")]
            ICEBERG,
            [InspectorName("Full Steam Ahead")]
            FULL_STEAM_AHEAD,
            [InspectorName("Armour Plating")]
            ARMOUR_PLATING,
            [InspectorName("Maneuverablity")]
            MANEUVERABILITY
        }

        [System.Serializable]
        public struct Position {
            public int lane;
            [Range(0, 1)]
            public float offset;
            public ElementType type;
        }

        public List<Position> positions;
        public float width;

    }
}
