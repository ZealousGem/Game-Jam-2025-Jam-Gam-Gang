using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    Scene scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

     public void GoToShip()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene(3);
    }


}
