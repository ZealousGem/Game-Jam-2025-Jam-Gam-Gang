using UnityEngine;
using UnityEngine.UI;

public class Notes : Interactable
{
    [SerializeField] Text[] notesText;
    [SerializeField] GameObject notesPanel;
    [SerializeField] NoteScriptableObject noteScriptable;
    int click = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (string notes in noteScriptable.notesList)
        {
            noteScriptable.notesQueue.Enqueue(notes);
        }

        int Qcount = 0;
        while (noteScriptable.notesQueue.Count > 0)
        {
            notesText[Qcount].text = noteScriptable.notesQueue.Dequeue();
            Qcount++;
        }
    }
    
    protected override void Interact()
    {
        notesPanel.SetActive(true);
        switch (click)
        {
             
            case 0:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                notesPanel.SetActive(true);
                notesText[0].gameObject.SetActive(true);
                notesText[1].gameObject.SetActive(false);
                notesText[2].gameObject.SetActive(false);
                click = 1;
                break;
            case 1:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                notesPanel.SetActive(true);
                notesText[0].gameObject.SetActive(false);
                notesText[1].gameObject.SetActive(true);
                notesText[2].gameObject.SetActive(false);
                click = 2;
                break;
            case 2:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                notesPanel.SetActive(true);
                notesText[0].gameObject.SetActive(false);
                notesText[1].gameObject.SetActive(false);
                notesText[2].gameObject.SetActive(true);
                click = 0;
                break;
        }
       
    }
    private void Awake()
    {
        notesPanel.SetActive(false);
    }
    public void CloseButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        notesPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
}
