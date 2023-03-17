using UnityEngine;

namespace Torn.Puzzles {
    public class WaterBlocks : MonoBehaviour
    {
        public enum BlockDirection {Horizontal, Vertical};

        [SerializeField] private BlockDirection blockDirection;
        [SerializeField] private float movementFactor;

        private int numberOfTimeClicked;

        public BlockDirection ReturnBlockDirection() {
            return blockDirection;
        }

        public float ReturnMovementFactor() {
            return movementFactor;
        }

        public int NumberOfTimeClicked {
            get {
                return numberOfTimeClicked;
            }
            set {
                if (value > -1 && value < 4) {
                    numberOfTimeClicked = value;
                }
                else {
                    numberOfTimeClicked = 0;
                }
            }
        }
    }
}