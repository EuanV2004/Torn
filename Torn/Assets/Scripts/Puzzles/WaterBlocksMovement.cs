using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Puzzles {
    public class WaterBlocksMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;

        private bool isInRange;
        private Collider2D collidingMovableObject;

        Torn.Interact.PlayerInteract player;

        private void Start() 
        {
            player = FindObjectOfType<Torn.Interact.PlayerInteract>();
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
            if (other.CompareTag("WaterPuzzleGoal")) {

                
                //SceneManager.LoadScene("House");
                //print("Won!");
                StartCoroutine(Transition("House", 12.34f, -4.34f, -5, "FadeIn"));
                
                
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

        IEnumerator Transition(string level, float x, float y, float z, string trigger)
        {
            player.GetComponent<Torn.Interact.PlayerInteract>().anim.SetTrigger("FadeOut");
            yield return new WaitForSecondsRealtime(1);
            player.GetComponent<Torn.Interact.PlayerInteract>().transform.position = new Vector3(x,y,z);
            SceneManager.LoadScene("House");
            player.GetComponent<Torn.Interact.PlayerInteract>().anim.SetTrigger("FadeIn");
            
            
        }
    }
}