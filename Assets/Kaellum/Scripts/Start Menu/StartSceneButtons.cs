using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject Press;
    [SerializeField]
    private GameObject Menu;

    public void PlayGame()
    {
        SceneManager.LoadScene(5);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Kaellum"));
    }

    public void Options()
    {
        Menu.SetActive(false);
        Press.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void quitMenu()
    {
        Menu.SetActive(true);
        Press.SetActive(false);
    }

    private void Start()
    {
        try
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Destroy(player);
            }
        }
        
        catch { }

        
    }

    
}
