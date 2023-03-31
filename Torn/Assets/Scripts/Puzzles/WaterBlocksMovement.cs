using UnityEngine;

namespace Torn.Puzzles {
    public class WaterBlocksMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        [SerializeField] private float stoppingDistance;
        [SerializeField] private LayerMask wallLayer;

        private int wallStopper;

        private bool isInRange;
        private bool wonHasRunOnce;
        private Collider2D collidingMovableObject;
        private WaterBlocksManager waterBlocksManager;

        private void Start() {
            waterBlocksManager = FindObjectOfType<WaterBlocksManager>();
        }

        private void Update() {
            if (CheckIfPlayerShouldStop(Vector2.right) == true || CheckIfPlayerShouldStop(Vector2.left) == true || CheckIfPlayerShouldStop(Vector2.up) == true || CheckIfPlayerShouldStop(Vector2.down) == true)
            {
                wallStopper = 0;
            }
            else
            {
                wallStopper = 1;
            }
            MovePlayer();
        }

        private void MovePlayer() {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");

            var horizontalMovement = horizontalInput * playerSpeed * Time.deltaTime * wallStopper;
            var verticalMovement = verticalInput * playerSpeed * Time.deltaTime * wallStopper;

            Vector3 newPos = transform.position + new Vector3(horizontalMovement, verticalMovement, 0f);
            transform.position = newPos;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Movable") || other.CompareTag("Movable2")) {
                collidingMovableObject = other;
                isInRange = true;
            }
            if (other.CompareTag("WaterPuzzleGoal") && !wonHasRunOnce) {
                wonHasRunOnce = true;
                waterBlocksManager.StartTransition();
            }
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (other.CompareTag("Movable") || other.CompareTag("Movable2")) {
                collidingMovableObject = other;
                isInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Movable")|| other.CompareTag("Movable2")) {
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

        private bool CheckIfPlayerShouldStop(Vector2 direction)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, stoppingDistance, wallLayer);

            if (hit.collider) return true;
            else return false;
        }
    }
}