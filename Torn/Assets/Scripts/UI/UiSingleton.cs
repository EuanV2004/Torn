using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSignleton : MonoBehaviour
{
    public static UiSignleton instance;

    private void Awake() {

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
