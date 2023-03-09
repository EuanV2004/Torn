using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Stack
{
    public class EndGame : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "BottomItem" && collision.gameObject.tag != "Resume")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
