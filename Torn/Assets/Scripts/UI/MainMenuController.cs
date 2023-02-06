using UnityEngine;
using UnityEngine.SceneManagement;

namespace Torn.UI
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartGame(int sceneIndex) 
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}