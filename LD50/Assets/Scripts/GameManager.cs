using UnityEngine;

namespace LD50
{
    public class GameManager : MonoBehaviour
    {
        public DifficultyData difficultyData;
        public float difficultyIncrease;
        public float speed = 3;
        public int laneCount = 3;
        public int xDistanceBetweenLane = 5;

        public GameStats globalStats;
        public GameStats roundStats;

        public Material waterMaterial;
        
        public bool isAlive = true;
        private static readonly int ZScrollSpeed = Shader.PropertyToID("_ZScrollSpeed");

        private void OnValidate()
        {
            waterMaterial.SetFloat(ZScrollSpeed, -speed);
        }

        private void Awake()
        {
            roundStats.Reset();
        }

        private void Update()
        {
            if(!isAlive) return;
            roundStats.timeSurvived += Time.deltaTime;
            var v = speed * Time.deltaTime * difficultyData.difficulty;
            difficultyIncrease += v;
            speed += v;
            waterMaterial.SetFloat(ZScrollSpeed, -speed / 2);
        }

        internal void IcebergDodged() {
            if (isAlive) {
                roundStats.icebergsDodged++;
            }
        }

        public int GetLaneXPosition(int lane) => 
            (lane - laneCount / 2) * xDistanceBetweenLane;

        public void AddRoundToGlobalStats()
        {
            globalStats.timeSurvived += roundStats.timeSurvived;
            globalStats.icebergsDodged += roundStats.icebergsDodged;
            globalStats.powerUpsCollected += roundStats.powerUpsCollected;
            globalStats.roundsPlayed += 1;
            globalStats.timeSurvivedHighScore = Mathf.Max(globalStats.timeSurvivedHighScore, roundStats.timeSurvived);
        }

        public void SetSpeed(float newSpeed)
        {
            speed = newSpeed;
            waterMaterial.SetFloat(ZScrollSpeed, -speed);
        }
    }
}
