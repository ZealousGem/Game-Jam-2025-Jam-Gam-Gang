using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject Press;
   public void PlayGame()
    {
        //SceneManager.GetSceneByName("Level 1");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level 1"));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Kaellum"));
    }

    public void Options()
    {
       Press.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void quitMenu()
    {
        Press.SetActive(false);
    }
}
