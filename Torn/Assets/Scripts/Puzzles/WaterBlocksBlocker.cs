using UnityEngine;

namespace Torn.Puzzles {
    public class WaterBlocksBlocker : MonoBehaviour
    {
        [SerializeField] private bool shouldFollowObject;
        [SerializeField] private GameObject objectCollider;

        private float yPos;

        private void Start() {
            yPos = objectCollider.transform.position.y;    
        }

        private void Update() {
            if (shouldFollowObject) {
                objectCollider.transform.position = new Vector3(objectCollider.transform.position.x, yPos, objectCollider.transform.position.z);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Object")) {
                objectCollider.SetActive(true);

                if (shouldFollowObject) {
                    objectCollider.transform.parent = other.transform;
                }
            }
        }
    }
}