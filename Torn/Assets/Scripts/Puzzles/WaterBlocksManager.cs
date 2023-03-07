using UnityEngine;

namespace Torn.Puzzles {
    public class WaterBlocksManager : MonoBehaviour
    {
        private void Start() {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        private void Update() {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null) return;

            if (Input.GetMouseButtonDown(0)) {
                if (hit.collider.CompareTag("Movable")) {
                    MoveBlock(hit);
                }
            }
        }

        private void MoveBlock(RaycastHit2D hit) {
            var block = hit.collider.GetComponent<WaterBlocks>();
            var blockDirection = block.ReturnBlockDirection();
            var movementFactor = block.ReturnMovementFactor();

            if (blockDirection == WaterBlocks.BlockDirection.Horizontal) {
                MoveBlockHorizontally(block, movementFactor);
            }
            else if (blockDirection == WaterBlocks.BlockDirection.Vertical) {
                MoveBlockVertically(block, movementFactor);
            }
        }

        private void MoveBlockHorizontally(WaterBlocks block, float movementFactor) {
            if (block.NumberOfTimeClicked == 0) {
                block.gameObject.transform.Translate(new Vector3(movementFactor, 0f, 0f));
                block.NumberOfTimeClicked++;
            }
            else if (block.NumberOfTimeClicked == 1) {
                block.gameObject.transform.Translate(new Vector3(-movementFactor, 0f, 0f));
                block.NumberOfTimeClicked++;
            }
            else if (block.NumberOfTimeClicked == 2) {
                block.gameObject.transform.Translate(new Vector3(-movementFactor, 0f, 0f));
                block.NumberOfTimeClicked++;
            }
            else if (block.NumberOfTimeClicked == 3) {
                block.gameObject.transform.Translate(new Vector3(movementFactor, 0f, 0f));
                block.NumberOfTimeClicked++;
            }
        }

        private void MoveBlockVertically(WaterBlocks block, float movementFactor) {
            if (block.NumberOfTimeClicked == 0) {
                block.gameObject.transform.Translate(new Vector3(0f, movementFactor, 0f));
                block.NumberOfTimeClicked++;
            }
            else if (block.NumberOfTimeClicked == 1) {
                block.gameObject.transform.Translate(new Vector3(0f, -movementFactor, 0f));
                block.NumberOfTimeClicked++;
            }
            else if (block.NumberOfTimeClicked == 2) {
                block.gameObject.transform.Translate(new Vector3(0f, -movementFactor, 0f));
                block.NumberOfTimeClicked++;
            }
            else if (block.NumberOfTimeClicked == 3) {
                block.gameObject.transform.Translate(new Vector3(0f, movementFactor, 0f));
                block.NumberOfTimeClicked++;
            }
        }
    }
}