using TMPro;
using UnityEngine;

namespace LD50.UI
{
    public class GameOverUI : MonoBehaviour
    {
        public GameStats globalStats;
        public GameStats roundStats;

        public TextMeshProUGUI r1;
        public TextMeshProUGUI r2;
        public TextMeshProUGUI r3;
        public TextMeshProUGUI g0;
        public TextMeshProUGUI g1;
        public TextMeshProUGUI g2;
        public TextMeshProUGUI g3;
        public TextMeshProUGUI g4;
        
        private const string S0 = "Highest Score: {0}";
        private const string S1B = "Score Sum: {0}";
        private const string S1 = "Score: {0}";
        private const string S2 = "Icebergs dodged: {0}";
        private const string S3 = "PowerUp's collected: {0}";
        private const string S4 = "Rounds played: {0}";

        private void Start()
        {
            g0.text = string.Format(S0, globalStats.timeSurvivedHighScore);
            g1.text = string.Format(S1B, globalStats.timeSurvived);
            g2.text = string.Format(S2, globalStats.icebergsDodged);
            g3.text = string.Format(S3, globalStats.powerUpsCollected);
            g4.text = string.Format(S4, globalStats.roundsPlayed);
            r1.text = string.Format(S1, roundStats.timeSurvived);
            r2.text = string.Format(S2, roundStats.icebergsDodged);
            r3.text = string.Format(S3, roundStats.powerUpsCollected);
        }
    }
}
