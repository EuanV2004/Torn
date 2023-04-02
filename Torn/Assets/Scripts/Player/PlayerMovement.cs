using UnityEngine;

namespace Torn.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float stoppingDistance;
        [SerializeField] private LayerMask wallLayer;

        int playerDirection;
        int wallStopper = 1;
        private Rigidbody2D rb;
        private float gravityScale;   
        private Animator animator;

        [SerializeField] Torn.Interact.PlayerInteract player;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            
            rb = GetComponent<Rigidbody2D>();
            gravityScale = rb.gravityScale;
            animator = GetComponent<Animator>();
            player = FindObjectOfType<Torn.Interact.PlayerInteract>();
        }

        void Update()
        {
            if (player.GetCanMove() == true)
            {
                Walk();
            }   
        }

        void Walk()
        {
            if (Input.GetKey(KeyCode.D)) // detect while walking is the player input
            {
                playerDirection = 1;

                if (CheckIfPlayerShouldStop(Vector2.right) == true)
                {
                    wallStopper = 0;
                    animator.SetBool("isWalking", false);
                }
                else
                {
                    wallStopper = 1;
                    animator.SetBool("isWalking", true);
                }

                transform.position += transform.right * Time.deltaTime * movementSpeed * wallStopper; // Time.deltaTime, it does not depend on the performance of your computer
                transform.rotation = Quaternion.Euler(0, 0, 0); // set the rotation of game object
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerDirection = -1;

                if (CheckIfPlayerShouldStop(Vector2.left) == true)
                {
                    wallStopper = 0;
                    animator.SetBool("isWalking", false);
                }
                else
                {
                    wallStopper = 1;
                    animator.SetBool("isWalking", true);
                }

                transform.position += transform.right * Time.deltaTime * movementSpeed * wallStopper;
                transform.rotation = Quaternion.Euler(0, 180, 0); //change y rotation to 180
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isWalking", false);
            }
        }

        private bool CheckIfPlayerShouldStop(Vector2 direction)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, stoppingDistance, wallLayer);

            if (hit.collider) return true;
            else return false;
        }

        public int ReturnPlayerDirection()
        {
            return playerDirection;
        }
    }
}