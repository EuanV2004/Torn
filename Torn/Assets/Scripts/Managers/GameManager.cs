using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> keys = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject key in keys)
        {
            if (FindObjectOfType<Torn.Interact.PlayerInteract>().GetPuzzleCount() < 4)
            {
                key.SetActive(false);
            }
            else
            {
                key.SetActive(true);
            }
        }
        
    }
}
