using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumbweCouner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numbers;
    private int numberOfClicks;

    public int NumberOfClicks {
        get {
            return numberOfClicks;
        }
        set {
            if (value > 0 && value < 5) {
                numberOfClicks = value;
            }
            else {
                numberOfClicks = 0;
            }
        }
    }

    private void Update() {
        numbers.text = NumberOfClicks.ToString();
    }
}