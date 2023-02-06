using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame(int sceneIndex) 
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
