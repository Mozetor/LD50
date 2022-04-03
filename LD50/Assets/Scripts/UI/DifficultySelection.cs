using System;
using TMPro;
using UnityEngine;

namespace LD50.UI
{
    public class DifficultySelection : MonoBehaviour
    {
        public DifficultyData difficultyData;
        private TMP_Dropdown _dropdown;

        private void Start()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            if (difficultyData.difficulty == 0) 
                difficultyData.difficulty = DifficultyData.EasyDifficultyFactor;
            _dropdown.value = difficultyData.difficulty switch
            {
                DifficultyData.MediumDifficultyFactor => 1,
                DifficultyData.HardDifficultyFactor => 2,
                _ => 0
            };
        }

        public void SetDifficulty()
        {
            difficultyData.difficulty = _dropdown.value switch
            {
                0 => DifficultyData.EasyDifficultyFactor,
                1 => DifficultyData.MediumDifficultyFactor,
                2 => DifficultyData.HardDifficultyFactor,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
