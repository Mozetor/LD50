using UnityEngine;

namespace LD50
{
    public class GameManager : MonoBehaviour
    {
        public int laneCount = 3;
        public int xDistanceBetweenLane = 5;

        public int GetLaneXPosition(int lane) => 
            (lane - laneCount / 2) * xDistanceBetweenLane;
    }
}
