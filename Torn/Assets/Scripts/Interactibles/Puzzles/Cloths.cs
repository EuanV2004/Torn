using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Torn.Interact
{
    public class Cloths : Interactable
    {
        public int weight;
        public Vector3 startPosition;

        public GameObject scalePlate;

        public TextMeshProUGUI weightText;

        // Start is called before the first frame update
        void Start()
        {
           startPosition = transform.position;
           weightText.text = weight.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if (interactedWith)
            {
                MoveToPlate();

                interactedWith = false;
            }
        }

        void MoveToPlate()
        {
            //transform.position = new Vector3(scalePlate.transform.position.x, scalePlate.transform.position.y + 0.8f, scalePlate.transform.position.z);

            gameObject.SetActive(false);

            scalePlate.transform.root.GetComponent<Scale>().AddWeight(this);

        }
    }
}
