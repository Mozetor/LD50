using UnityEngine;

namespace LD50
{
    public class GameManager : MonoBehaviour
    {
        public int laneCount = 3;
        public int xDistanceBetweenLane = 5;

        public GameStats globalStats;
        public GameStats roundStats;

        private void Awake()
        {
            roundStats.Reset();
        }

        private void Update()
        {
            roundStats.timeSurvived += Time.deltaTime;
        }

        public int GetLaneXPosition(int lane) => 
            (lane - laneCount / 2) * xDistanceBetweenLane;

        public void AddRoundToGlobalStats()
        {
            globalStats.timeSurvived += roundStats.timeSurvived;
            globalStats.icebergsDodged += roundStats.icebergsDodged;
            globalStats.powerUpsCollected += roundStats.powerUpsCollected;
            globalStats.roundsPlayed += 1;
        }
    }
}
