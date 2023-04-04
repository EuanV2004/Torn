using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnim : MonoBehaviour
{
    [SerializeField] GameObject image;

    public void Disable()
    {
        image.SetActive(false);
    }
}
