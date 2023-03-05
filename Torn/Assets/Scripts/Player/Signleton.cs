using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signleton : MonoBehaviour
{
    private void Awake()
        
    {

        for (int i = 0; i < Object.FindObjectsOfType<Signleton>().Length; i++)
        {
            if (Object.FindObjectsOfType<Signleton>()[i] != this)
            {
                if (Object.FindObjectsOfType<Signleton>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
