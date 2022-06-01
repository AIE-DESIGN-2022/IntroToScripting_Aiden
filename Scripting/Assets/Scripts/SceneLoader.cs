using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Loads selected scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}