using UnityEngine;

namespace LD50
{
    [CreateAssetMenu(fileName = "New Difficulty Data", menuName = "Difficulty Data", order = 0)]
    public class DifficultyData : ScriptableObject
    {
        public const float EasyDifficultyFactor = 0.002f;
        public const float MediumDifficultyFactor = 0.005f;
        public const float HardDifficultyFactor = 0.01f;
        
        public float difficulty = EasyDifficultyFactor;
    }
}