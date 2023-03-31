using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Keys")]
    [SerializeField] List<GameObject> keys = new List<GameObject>();
    [SerializeField] GameObject realKey;
    [Header("Puzzles")]
    [SerializeField] GameObject audioPuzzle;
    [SerializeField] GameObject clothesPuzzle;
    [SerializeField] GameObject logicPuzzle;
    [SerializeField] GameObject waterPuzzle;
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

        if (FindObjectOfType<Torn.Interact.PlayerInteract>().GetPuzzleCount() < 4)
        {
            realKey.SetActive(false);
        }
        else
        {
            realKey.SetActive(true);

            if (FindObjectOfType<Torn.Interact.PlayerInteract>().GetKeyCount() < 4)
            {
                realKey.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                realKey.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        
        if (FindObjectOfType<Torn.Interact.PlayerInteract>().GetPlayedAudioPuzzle())
        {
            audioPuzzle.SetActive(false);
        }
        else
        {
            audioPuzzle.SetActive(true);
        }

        if (FindObjectOfType<Torn.Interact.PlayerInteract>().GetPlayedClothesPuzzle())
        {
            clothesPuzzle.SetActive(false);
        }
        else
        {
            clothesPuzzle.SetActive(true);
        }

        if (FindObjectOfType<Torn.Interact.PlayerInteract>().GetPlayedLogicPuzzle())
        {
            logicPuzzle.SetActive(false);
        }
        else
        {
            logicPuzzle.SetActive(true);
        }

        if (FindObjectOfType<Torn.Interact.PlayerInteract>().GetPlayedWaterPuzzle())
        {
            waterPuzzle.SetActive(false);
        }
        else
        {
            waterPuzzle.SetActive(true);
        }
    }
}
