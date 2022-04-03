using TMPro;
using UnityEngine;

namespace LD50.UI
{
    public class ScoreUI : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        

        private GameManager _gameManager;
        private const string S = "Score: {0}";
        
        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            scoreText.text = string.Format(S, _gameManager.roundStats.timeSurvived.ToString("0.00"));
        }
    }
}
