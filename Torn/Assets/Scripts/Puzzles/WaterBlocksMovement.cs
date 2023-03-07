using UnityEngine;

namespace Torn.Puzzles {
    public class WaterBlocksMovement : MonoBehaviour
    {
        public enum MovementDirection {Left, Right, Down};

        [SerializeField] private MovementDirection movementDirection;

        public MovementDirection ReturnMovementDirection() {
            return movementDirection;
        }
    }
}