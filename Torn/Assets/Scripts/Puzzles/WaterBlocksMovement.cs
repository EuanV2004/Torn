using UnityEngine;

namespace Torn.Puzzles {
    public class WaterBlocksMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;

        private bool isInRange;
        private bool wonHasRunOnce;
        private Collider2D collidingMovableObject;
        private WaterBlocksManager waterBlocksManager;

        private void Start() {
            waterBlocksManager = FindObjectOfType<WaterBlocksManager>();
        }

        private void Update() {
            MovePlayer();
        }

        private void MovePlayer() {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");

            var horizontalMovement = horizontalInput * playerSpeed * Time.deltaTime;
            var verticalMovement = verticalInput * playerSpeed * Time.deltaTime;

            Vector3 newPos = transform.position + new Vector3(horizontalMovement, verticalMovement, 0f);
            transform.position = newPos;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Movable")) {
                collidingMovableObject = other;
                isInRange = true;
            }
            if (other.CompareTag("WaterPuzzleGoal") && !wonHasRunOnce) {
                wonHasRunOnce = true;
                waterBlocksManager.StartTransition();
            }
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (other.CompareTag("Movable")) {
                collidingMovableObject = other;
                isInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Movable")) {
                collidingMovableObject = null;
                isInRange = false;
            }
        }

        public bool ReturnIsInRange() {
            return isInRange;
        }

        public Collider2D ReturnCollidingMovableObject() {
            return collidingMovableObject;
        }
    }
}