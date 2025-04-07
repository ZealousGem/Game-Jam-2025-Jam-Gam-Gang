using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject PauseMenuScr;
    bool isPaused;
    bool dead;
    public GameObject DeathScr;
    
    void Start()
    {
        PauseMenuScr.SetActive(false);
        isPaused = false;
        DeathScr.SetActive(false);
        dead = false;
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

        if (PlayerHeallth.instance.currentHealth == 0 && !dead)
        {
            dead = true;
            StartCoroutine(DeathUI());
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

    public IEnumerator DeathUI()
    {
        yield return new WaitForSeconds(2f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DeathScr.SetActive(true);

    }

  public  void RestartCheckpoint()
    {
        PlayerHeallth.instance.RespawnState();
        dead = false;
        DeathScr.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

   public void QuitLevel()
    {
        
    }
}
