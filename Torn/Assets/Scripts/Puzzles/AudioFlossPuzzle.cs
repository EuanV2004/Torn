using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.Puzzles
{
    public class AudioFlossPuzzle : MonoBehaviour
    {
        private List<int> noteOrder = new List<int>() {1, 4, 3, 2, 3};
        private List<int> userOrder = new List<int>();

        private bool isInRange;
        private bool shouldStillInteract = true;
        private AudioFlossNote currentNote;
        private AudioManager audioManager;
        public GameObject pill;
        public Vector3 location;
        int i;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.E) && isInRange) {
                InteractWithAudioFloss();
            }

            if (userOrder.Count > 4) {
                StartCoroutine(BeginNoteCheck());
            }
        }

        private void OnTriggerStay2D(Collider2D other) {
            if (other.CompareTag("AudioFloss")) {
                isInRange = true;
                currentNote = other.gameObject.GetComponent<AudioFlossNote>();
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("AudioFloss")) {
                isInRange = false;
                currentNote = null;
            }
        }

        private void InteractWithAudioFloss() {
            if (!shouldStillInteract) return; 
            if (!audioManager) return;
            if (!currentNote) return;

            switch (currentNote.GetCurrentNote()) {
                case Notes.E:
                    print ("E");
                    audioManager.Play("E");
                    userOrder.Add(1);
                    break;
                case Notes.G:
                    print ("G");
                    audioManager.Play("G");
                    userOrder.Add(2);
                    break;
                case Notes.A:
                    print ("A");
                    audioManager.Play("A");
                    userOrder.Add(3);
                    break;
                case Notes.B:
                    print ("B");
                    audioManager.Play("B");
                    userOrder.Add(4);
                    break;
                case Notes.D:
                    print ("D");
                    audioManager.Play("D");
                    userOrder.Add(5);
                    break;
            }
        }

        private IEnumerator BeginNoteCheck() {
            bool isOrderSame = userOrder.SequenceEqual(noteOrder);

            if (isOrderSame) {
                print("Order is correct!");

                shouldStillInteract = false;
                yield return new WaitForSeconds(0.5f);

                userOrder.Clear();
                if (i == 0)
                {
                    Instantiate(pill, location, Quaternion.identity);
                    i++;
                }
                //transform.position = new Vector3(76f, -3.56f, -5f);
                //SceneManager.LoadScene("House");
            }
            else {
                print("Order is incorrect!");
                yield return new WaitForSeconds(0.5f);

                userOrder.Clear();
                shouldStillInteract = true;
                print("Try again!");
            }
        }
    }
}