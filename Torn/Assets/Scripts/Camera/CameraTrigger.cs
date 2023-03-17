using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 newCameraPos = new Vector3(0f, 0f, -10f);

    private bool hasPassedOnce;
    private int numberOfTimesPassed;
    private Vector3 oldCameraPos;
    private Camera cam;

    private void Start() {
        cam = Camera.main;    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (!hasPassedOnce) {
                oldCameraPos = cam.transform.position;
                hasPassedOnce = true;
            }

            if (numberOfTimesPassed % 2 == 0) {
                // Going to new place
                cam.transform.position = newCameraPos;
                numberOfTimesPassed++;
            }
            else {
                // Going to original place
                cam.transform.position = oldCameraPos;
                numberOfTimesPassed++;
            }
        }
    }
}