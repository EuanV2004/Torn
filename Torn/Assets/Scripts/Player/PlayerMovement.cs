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

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            gravityScale = rb.gravityScale;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.D)) // detect while walking is the player input
            {
                playerDirection = 1;

                if (CheckIfPlayerShouldStop(Vector2.right) == true)
                {
                    wallStopper = 0;
                }
                else
                {
                    wallStopper = 1;
                }

                transform.position += transform.right * Time.deltaTime * movementSpeed * wallStopper; // Time.deltaTime, it does not depend on the performance of your computer
                transform.rotation = Quaternion.Euler(0, 0, 0); // set the rotation of game object
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerDirection = -1;

                if (CheckIfPlayerShouldStop(Vector2.left) == true)
                {
                    wallStopper = 0;
                }
                else
                {
                    wallStopper = 1;
                }

                transform.position += transform.right * Time.deltaTime * movementSpeed * wallStopper;
                transform.rotation = Quaternion.Euler(0, 180, 0); //change y rotation to 180
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