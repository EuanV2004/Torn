using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager instance;
    [Header("LivingRoom")]
    public GameObject objectToMove1;
    public GameObject objectToMove2;
    public Vector3 newPosition1;
    public Vector3 newPosition2;
    [Header("Hall")]
    public GameObject objectToMove3;
    public Vector3 newPosition3;
    [Header("Bedroom")]
    public GameObject objectToMove4;
    public Vector3 newPosition4;
    [Header("Bathroom")]
    public GameObject objectToMove5;
    public Vector3 newPosition5;
    
    [Header("Unloaded")]
    public Vector3 unloadedPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LivingRoom")
        {
            objectToMove1.transform.position = newPosition1;
            objectToMove2.transform.position = newPosition2;
        }
        else if (scene.name != "LivingRoom")
        {
            objectToMove1.transform.position = unloadedPosition;
            objectToMove2.transform.position = unloadedPosition;
        }
        if (scene.name == "Home")
        {
            objectToMove3.transform.position = newPosition3;
        }
        else if (scene.name != "Home")
        {
            objectToMove3.transform.position = unloadedPosition;
        }
        if (scene.name == "Bedroom")
        {
            objectToMove4.transform.position = newPosition4;
        }
        else if (scene.name != "Bedroom")
        {
            objectToMove4.transform.position = unloadedPosition;
        }
        if (scene.name == "Bathroom")
        {
            objectToMove5.transform.position = newPosition5;
        }
        else if (scene.name != "Bathroom")
        {
            objectToMove5.transform.position = unloadedPosition;
        }
    }

    /*private void OnSceneUnloaded(Scene scene)
    {
        if (scene.name != "LivingRoom")
        {
            objectToMove1.transform.position = unloadedPosition;
            objectToMove2.transform.position = unloadedPosition;
        }
        if (scene.name != "Home")
        {
            objectToMove3.transform.position = unloadedPosition;
        }
        else if (scene.name != "Bedroom")
        {
            objectToMove4.transform.position = unloadedPosition;
        }
        else if (scene.name != "Bathroom")
        {
            objectToMove5.transform.position = unloadedPosition;
        }
    }*/
}
