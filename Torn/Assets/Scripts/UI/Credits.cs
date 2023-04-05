using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject credits;

    private void Start() 
    {
        title.SetActive(false);
        credits.SetActive(false);
    }

    public void StartCredits()
    {
        title.SetActive(true);
        credits.SetActive(true);
    }
}
