using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableVisibility : MonoBehaviour
{
    [SerializeField] private GameObject bearSprite;
    [SerializeField] private GameObject soapSprite;
    [SerializeField] private GameObject bookSprite;
    [SerializeField] private GameObject photoSprite;
    [SerializeField] private GameObject coatSprite;

    public void EnableBearSprite() {
        bearSprite.SetActive(true);
    }

    public void EnableSoapSprite() {
        soapSprite.SetActive(true);
    }

    public void EnableBookSprite() {
        bookSprite.SetActive(true);
    }

    public void EnablePhotoSprite() {
        photoSprite.SetActive(true);
    }

    public void EnableCoatSprite() {
        coatSprite.SetActive(true);
    }
}