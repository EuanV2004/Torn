using UnityEngine;

namespace Torn.Puzzles {
    public class WaterBlocksObject : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float raycastDistanceHorizontal;
        [SerializeField] private float raycastDistanceVertical;
        [SerializeField] private LayerMask layer;

        private RaycastHit2D hitRight;
        private RaycastHit2D hitLeft;
        private RaycastHit2D hitDown;
        private bool hasWon;
        private WaterBlocksMovement.MovementDirection otherMovementDirection;

        private void Update() {
            hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastDistanceHorizontal, layer);
            hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastDistanceHorizontal, layer);
            hitDown = Physics2D.Raycast(transform.position, Vector2.down, raycastDistanceVertical, layer);
        }

        private void FixedUpdate() {
            if (hasWon) return;

            if (otherMovementDirection == WaterBlocksMovement.MovementDirection.Right) {
                if (hitRight.collider == null) {
                    transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
                }
            }
            else if (otherMovementDirection == WaterBlocksMovement.MovementDirection.Down) {
                if (hitDown.collider == null) {
                    transform.Translate(0f, -movementSpeed * Time.deltaTime, 0f);
                }
            }
            else if (otherMovementDirection == WaterBlocksMovement.MovementDirection.Left) {
                if (hitLeft.collider == null) {
                    transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("MovementDecider")) {
                otherMovementDirection = other.GetComponent<WaterBlocksMovement>().ReturnMovementDirection();
            }
            if (other.CompareTag("WaterPuzzleGoal")) {
                print("Won the level!");
                hasWon = true;
            }
        }
    }
}