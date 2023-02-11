using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Torn.Interact {
    public class Scale : Interactable
    {
        public TextMeshProUGUI leftScaleText, rightScaleText;

        public int leftTotal, rightTotal;

        public GameObject scaleArm;
        public GameObject leftSide;
        public GameObject rightSide;

        Vector3 startLeftPos, startRightPos;


        List<GameObject> clothesObjects = new List<GameObject>();
        //GameObject leftObject, rightObject;

        // Start is called before the first frame update
        void Start()
        {
            startLeftPos = leftSide.transform.position;
            startRightPos = rightSide.transform.position;

            leftScaleText.text = "0";
            rightScaleText.text = "0";
        }

        // Update is called once per frame
        void Update()
        {
            if (interactedWith && (leftTotal > 0 || rightTotal > 0)) 
            {
                RemoveWeight();
            }

            BalanceWeight();
        }

        void BalanceWeight()
        {
            // When left side weights more then right side
            if (leftTotal > rightTotal)
            {
                scaleArm.transform.rotation = new Quaternion(0, 0, -15, 1);
                leftSide.transform.position = new Vector3(startLeftPos.x, startLeftPos.y - 0.5f, startLeftPos.z);
                rightSide.transform.position = new Vector3(startRightPos.x, startRightPos.y + 0.5f, startRightPos.z);

            }
            // When right side weights more than left side
            else if (rightTotal > leftTotal)
            {
                scaleArm.transform.rotation = new Quaternion(0, 0, 15, 1);
                leftSide.transform.position = new Vector3(startLeftPos.x, startLeftPos.y + 0.5f, startLeftPos.z);
                rightSide.transform.position = new Vector3(startRightPos.x, startRightPos.y - 0.5f, startRightPos.z);

            }
            // When both sides are equally balanced
            else if (leftTotal == rightTotal)
            {
                scaleArm.transform.rotation = Quaternion.identity;  // Reset rotation
                leftSide.transform.position = startLeftPos;
                rightSide.transform.position = startRightPos;
            }

            /*if (leftObject != null) 
                leftObject.transform.position = new Vector3(
                    leftObject.GetComponent<Cloths>().scalePlate.transform.position.x,
                    leftObject.GetComponent<Cloths>().scalePlate.transform.position.y + 0.8f,
                    leftObject.GetComponent<Cloths>().scalePlate.transform.position.z);
            
            if (rightObject != null) 
                rightObject.transform.position = new Vector3(
                    rightObject.GetComponent<Cloths>().scalePlate.transform.position.x,
                    rightObject.GetComponent<Cloths>().scalePlate.transform.position.y + 0.8f,
                    rightObject.GetComponent<Cloths>().scalePlate.transform.position.z);*/
        }

        void UpdateText()
        {
            leftScaleText.text = leftTotal.ToString();
            rightScaleText.text = rightTotal.ToString();
        }

        // Adds clothes to scale
        public void AddWeight(Cloths clothes)
        {
            switch (clothes.scalePlate.name) 
            {
                case "LPlate":
                    {
                        leftTotal += clothes.weight;
                        //leftObject = clothes.gameObject;

                        break;
                    }
                case "RPlate":
                    {
                        rightTotal += clothes.weight;
                        //rightObject = clothes.gameObject;

                        break;
                    }
            }

            clothesObjects.Add(clothes.gameObject);

            UpdateText();
        }


        // Removes ALL cloths
        public void RemoveWeight()
        {
            leftTotal = 0;
            rightTotal = 0;

            UpdateText();

            foreach (GameObject obj in clothesObjects)
            {
                if (obj != null && obj.activeSelf != true)
                {
                    obj.SetActive(true);
                }
                
            }

            /*if (leftObject != null)
            {
                //leftObject.transform.position = leftObject.GetComponent<Cloths>().startPosition;
            }
            if (rightObject != null)
            {
                //rightObject.transform.position = rightObject.GetComponent<Cloths>().startPosition;
            }

            leftObject = null;
            rightObject = null;*/

            interactedWith = false;
        }
    }
}
