using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPull : MonoBehaviour
{
    [SerializeField]
    float pullForce;

    Rigidbody2D body;

    [SerializeField]
    bool outOfStack;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        outOfStack = false;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Stack")
        {
            outOfStack = true;
            body.velocity = Vector2.zero;
        }
        else
        {
            outOfStack = false;
        }
    }
}
