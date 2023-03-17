using UnityEngine;

public class TEMPKeyCue : MonoBehaviour
{
    [SerializeField] private GameObject keyCue;
    private bool hasPassedOnce = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            keyCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !hasPassedOnce) {
            keyCue.SetActive(true);
            hasPassedOnce = true;
        }
    }
}