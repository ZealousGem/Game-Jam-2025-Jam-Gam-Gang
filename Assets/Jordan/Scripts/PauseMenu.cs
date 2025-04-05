using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject PauseMenuScr;
    bool isPaused; 
    void Start()
    {
        PauseMenuScr.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }

            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        PauseMenuScr.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

 public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        PauseMenuScr.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

  public  void RestartCheckpoint()
    {

    }

   public void QuitLevel()
    {
        
    }
}
