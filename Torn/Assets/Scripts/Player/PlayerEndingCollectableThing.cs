using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndingCollectableThing : MonoBehaviour
{
    private CollectableVisibility collectableVisibility;
    private bool isBear;
    private bool isBook;
    private bool isCoat;
    private bool isPicture;
    private bool isSoap;

    private void Start() {
        collectableVisibility = FindObjectOfType<CollectableVisibility>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isBear) collectableVisibility.EnableBearSprite();
            if (isBook) collectableVisibility.EnableBookSprite();
            if (isCoat) collectableVisibility.EnableCoatSprite();
            if (isPicture) collectableVisibility.EnablePhotoSprite();
            if (isSoap) collectableVisibility.EnableSoapSprite();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        CollectableType collectableScript;
        collectableScript = other.GetComponent<CollectableType>();

        if (collectableScript == null) return;

        Collectable collectableType = other.GetComponent<CollectableType>().ReturnCollectableType();
        print(collectableType);

        if (collectableType == Collectable.Bear) {
            isBear = true;
            isBook = false;
            isCoat = false;
            isPicture = false;
            isSoap = false;
        }
        if (collectableType == Collectable.Book) {
            isBook = true;
            isBear = false;
            isCoat = false;
            isPicture = false;
            isSoap = false;
        }
        if (collectableType == Collectable.Coat) {
            isCoat = true;
            isBear = false;
            isBook = false;
            isPicture = false;
            isSoap = false;
        }
        if (collectableType == Collectable.Picture) {
            isPicture = true;
            isCoat = false;
            isBear = false;
            isBook = false;
            isSoap = false;
        }
        if (collectableType == Collectable.Soap) {
            isSoap = true;
            isPicture = false;
            isCoat = false;
            isBear = false;
            isBook = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isBear = false;
            isBook = false;
            isCoat = false;
            isPicture = false;
            isSoap = false;
    }
}