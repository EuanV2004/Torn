using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectable {Bear, Soap, Book, Picture, Coat};

public class CollectableType : MonoBehaviour
{
    [SerializeField] private Collectable collectableType;

    public Collectable ReturnCollectableType() {
        return collectableType;
    }
}