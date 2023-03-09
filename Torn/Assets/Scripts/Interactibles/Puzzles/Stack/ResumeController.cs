using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Stack
{
    public class ResumeController : MonoBehaviour
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
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    body.AddForce(Vector2.left * pullForce, ForceMode2D.Impulse);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    body.AddForce(Vector2.right * pullForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                body.velocity = Vector2.zero;
            }

        }

        public void SetForceMuliplier(float pos = 0, float size = 0)
        {
            if (pos <= 0 &&  size <= 0)
            {
                pullForce = 3f;
            }
            else
            {
                pullForce = 3f + (2f / (pos + 1) + (0.1f * (size - pos)));
            }

            Debug.Log($"New pull force: {pullForce}");
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
