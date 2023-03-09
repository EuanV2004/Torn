using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Stack
{
    public class ObjectPull : MonoBehaviour
    {
        [SerializeField]
        float pullForce = 3f;

        Rigidbody2D body;

        [SerializeField]
        bool outOfStack;

        bool hardModeOn;

        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (!outOfStack)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    body.AddForce(Vector2.left * pullForce, ForceMode2D.Impulse);
                }

                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    body.AddForce(Vector2.right * pullForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                body.velocity = Vector2.zero;
            }

        }

        public void SetForceMuliplier(float m)
        {
            //Debug.Log($"pullForce = {m}");
            pullForce = m;
        }

        public void HardmodeOn (bool b = false)
        {
            hardModeOn = b;
        }

        public bool CheckHardmode()
        {
            return hardModeOn;
        }

        void RestartGame()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Table" && !hardModeOn)
            {
                outOfStack = true;
                body.velocity = Vector2.zero;

                RestartGame();

            }
            else
            {
                outOfStack = false;
            }
        }
    }
}
