using UnityEngine;

namespace Torn.Puzzles {
    public class WaterBlocksMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;

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
            if (other.CompareTag("WaterPuzzleGoal")) {
                print("Won!");
            }
        }
    }
}