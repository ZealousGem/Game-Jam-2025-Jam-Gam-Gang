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
        try
        {
            AudioManager.Instance.PlaySound("click");
            AudioManager.Instance.StopMusic("theme");
            AudioManager.Instance.PlaySound ("dialogue");
        }
        catch { }
        SceneManager.LoadScene(5);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Kaellum"));
    }

    public void Options()
    {
        try
        {
            AudioManager.Instance.PlaySound("click");
        }
        catch { }
        Menu.SetActive(false);
        Press.SetActive(true);
    }

    public void QuitGame()
    {
        try
        {
            AudioManager.Instance.PlaySound("click");
        }
        catch { }
        Application.Quit();
    }

    public void quitMenu()
    {
        try
        {
            AudioManager.Instance.PlaySound("click");
        }
        catch { }
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
        
        catch {

           
        
        }
       
       

        
    }

    
}
