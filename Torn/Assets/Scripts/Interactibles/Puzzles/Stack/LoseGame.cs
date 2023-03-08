using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseGame : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "BottomItem" && collision.gameObject.tag != "Resume")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
