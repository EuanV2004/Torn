using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Puzzles {
    public class WaterBlocksManager : MonoBehaviour
    {
        [SerializeField] private LayerMask movableLayer;
        private WaterBlocksMovement waterBlocksMovement;
        private Torn.Interact.PlayerInteract player;

        private void Start() {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            waterBlocksMovement = FindObjectOfType<WaterBlocksMovement>();
            player = FindObjectOfType<Torn.Interact.PlayerInteract>();
        }

        private void Update() {
            if (!waterBlocksMovement.ReturnIsInRange()) return;

            Collider2D movableBlock = waterBlocksMovement.ReturnCollidingMovableObject();

            if (Input.GetKeyDown(KeyCode.E)) {
                MoveBlock(movableBlock);
            }
        }

        private void MoveBlock(Collider2D other) {
            var block = other.GetComponent<WaterBlocks>();
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

        public void StartTransition() {
            StartCoroutine(Transition("House", 15.84f, -4.34f, -5, "FadeIn"));
        }

        IEnumerator Transition(string level, float x, float y, float z, string trigger)
        {
            player.GetComponent<Torn.Interact.PlayerInteract>().anim.SetTrigger("FadeOut");
            print($"Calling fade out from object: {gameObject.name}");
            yield return new WaitForSecondsRealtime(1);
            player.GetComponent<Torn.Interact.PlayerInteract>().transform.position = new Vector3(x, y, z);
            SceneManager.LoadScene("House");
            player.GetComponent<Torn.Interact.PlayerInteract>().anim.SetTrigger("FadeIn");
        }
    }
}