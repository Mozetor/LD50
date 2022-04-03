using TMPro;
using UnityEngine;

namespace LD50.UI
{
    public class GlobalStatsUI : MonoBehaviour
    {
        public GameStats globalStats;
        
        public TextMeshProUGUI g0;
        public TextMeshProUGUI g1;
        public TextMeshProUGUI g2;
        public TextMeshProUGUI g3;
        public TextMeshProUGUI g4;
        
        private const string S0 = "Highest Score: {0}";
        private const string S1B = "Score Sum: {0}";
        private const string S2 = "Icebergs dodged: {0}";
        private const string S3 = "PowerUp's collected: {0}";
        private const string S4 = "Rounds played: {0}";

        private void Start()
        {
            g0.text = string.Format(S0, globalStats.timeSurvivedHighScore.ToString("0.00"));
            g1.text = string.Format(S1B, globalStats.timeSurvived.ToString("0.00"));
            g2.text = string.Format(S2, globalStats.icebergsDodged);
            g3.text = string.Format(S3, globalStats.powerUpsCollected);
            g4.text = string.Format(S4, globalStats.roundsPlayed);
        }
    }
}
