using UnityEngine;

namespace LD50
{
    [CreateAssetMenu(menuName = "GameStats")]
    public class GameStats : ScriptableObject
    {
        public float timeSurvived;
        public int powerUpsCollected;
        public int icebergsDodged;
        public int roundsPlayed;

        public void Reset()
        {
            timeSurvived = 0;
            powerUpsCollected = 0;
            icebergsDodged = 0;
            roundsPlayed = 0;
        }
    }
}
