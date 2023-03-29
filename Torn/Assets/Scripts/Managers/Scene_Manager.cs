using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    // public static Scene_Manager instance;
    // [Header("LivingRoom")]
    // public GameObject objectToMove1;
    // public GameObject objectToMove2;
    // public Vector3 newPosition1;
    // public Vector3 newPosition2;
    // [Header("Hall")]
    // public GameObject objectToMove3;
    // public Vector3 newPosition3;
    // [Header("Bedroom")]
    // public GameObject objectToMove4;
    // public Vector3 newPosition4;
    // [Header("Bathroom")]
    // public GameObject objectToMove5;
    // public Vector3 newPosition5;
    
    // [Header("Unloaded")]
    // public Vector3 unloadedPosition;

    // [Header("Player")]
    // public GameObject Player;

    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // private void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    //     //SceneManager.sceneUnloaded += OnSceneUnloaded;
    // }

    // private void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    //     //SceneManager.sceneUnloaded -= OnSceneUnloaded;
    // }

    // private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     if (scene.name == "House")
    //     {
    //         objectToMove1.transform.position = newPosition1;
    //         objectToMove2.transform.position = newPosition2;
    //         objectToMove3.transform.position = newPosition3;
    //         objectToMove4.transform.position = newPosition4;
    //         objectToMove5.transform.position = newPosition5;
    //     }
    //     else if (scene.name != "House")
    //     {
    //         objectToMove1.transform.position = unloadedPosition;
    //         objectToMove2.transform.position = unloadedPosition;
    //         objectToMove3.transform.position = unloadedPosition;
    //         objectToMove4.transform.position = unloadedPosition;
    //         objectToMove5.transform.position = unloadedPosition;
    //     }
    // }

    /*private void OnSceneUnloaded(Scene scene)
    {
        if (scene.name != "House")
        {
            Player.transform.position = new Vector3(0,0,0);
        }
    }*/
}
