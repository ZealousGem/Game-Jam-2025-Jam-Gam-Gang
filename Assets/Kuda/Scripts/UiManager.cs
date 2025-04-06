using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject minigame;
    public GameObject articleScreen;
    public GameObject desktopScreen;
    public GameObject passwordScreen;

    private void Start()
    {
        //desktopScreen.SetActive(true);
        minigame.SetActive(false);
        articleScreen.SetActive(false);
        passwordScreen.SetActive(false);
    }

   public void SelectMiniGame()
    {
        desktopScreen.SetActive(false);
        minigame.SetActive(true);
        articleScreen.SetActive(false);
        passwordScreen.SetActive(false);
    }

   public void SelectArticle()
    {
        desktopScreen.SetActive(false);
        minigame.SetActive(false);
        articleScreen.SetActive(true);
        passwordScreen.SetActive(false);
    }

   public void SelectPassword()
    {
        desktopScreen.SetActive(false);
        minigame.SetActive(false);
        articleScreen.SetActive(false);
        passwordScreen.SetActive(true);
    }

    public void CloseApp()
    {
        desktopScreen.SetActive(true);
        minigame.SetActive(false);
        articleScreen.SetActive(false);
        passwordScreen.SetActive(false);
    }
}
