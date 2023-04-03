using UnityEngine;

public class TEMPKeyCue : MonoBehaviour
{
    [SerializeField] private GameObject keyCue;
    [SerializeField] private bool hidden;
    private bool hasPassedOnce = false;

    int keyCount;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            keyCue.SetActive(false);
        }

        keyCount = FindObjectOfType<Torn.Interact.PlayerInteract>().GetKeyCount();

        if (keyCount >= 4)
        {
            hidden = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){ //&& !hasPassedOnce) {
            if (!hidden)
            {
                keyCue.SetActive(true);
            }
            //hasPassedOnce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")){ //&& !hasPassedOnce) {
            keyCue.SetActive(false);
            //hasPassedOnce = true;
        }
    }
}