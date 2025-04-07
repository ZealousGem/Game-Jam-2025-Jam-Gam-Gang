using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject PauseMenuScr;
    bool isPaused;
    bool dead;
    public UnityEvent itHappens;
    public GameObject DeathScr;
    public GameObject ExplosionUI;
    public TMP_Text TimeText;
  //  public TMP_Text objText;
        void Start()
    {
        PauseMenuScr.SetActive(false);
        isPaused = false;
        DeathScr.SetActive(false);
        //ExplosionTimer.Instance.AddListener(OnExplosionStart);

        switch (ExplosionTimer.Instance.beginTime)
        {
            case true: ExplosionUI.SetActive(true); break;
            case false: ExplosionUI.SetActive(false); break;

        }
       
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


        if (ExplosionTimer.Instance.beginTime && !ExplosionTimer.Instance.startExpo && !ExplosionUI.activeSelf)
        {
            //    StartCoroutine(expUI());
            ExplosionTimer.Instance.startExpo = true;
             itHappens?.Invoke();
        }

        if (ExplosionUI.activeSelf && ExplosionTimer.Instance.endSeq)
        {
            Timing();
        }

    }

    public void turonUI()
    {
        StartCoroutine(expUI());
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
        Checkpoints checking = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Checkpoints>();
        checking.Respawn();
        PlayerHeallth.instance.RespawnState();
        dead = false;
        DeathScr.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void Timing()
    {
        TimeText.text = ExplosionTimer.Instance.timer.ToString();
    }

   public IEnumerator expUI()
    {
      //  ExplosionTimer.Instance.startExpo = false;
        ExplosionUI.SetActive(true);
        TimeText.text = "Self Destruction imminent";
        yield return new WaitForSeconds(2f);
        TimeText.text = "Run!!!!";
        yield return new WaitForSeconds(5f);
        ExplosionTimer.Instance.endSeq = true;
        Timing();
    }

   public void QuitLevel()
    {
        
    }
}
