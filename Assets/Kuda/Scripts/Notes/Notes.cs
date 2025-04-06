using UnityEngine;
using UnityEngine.UI;

public class Notes : Interactable
{
    [SerializeField] Text[] notesText;
    [SerializeField] GameObject notesPanel;
    [SerializeField] NoteScriptableObject noteScriptable;
    int click = 0;

    public Button closeButton;
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
        switch (click)
        {
            case 0:
                notesPanel.SetActive(true);
                notesText[0].gameObject.SetActive(true);
                notesText[1].gameObject.SetActive(false);
                notesText[2].gameObject.SetActive(false);
                break;
            case 1:
                notesPanel.SetActive(true);
                notesText[0].gameObject.SetActive(false);
                notesText[1].gameObject.SetActive(true);
                notesText[2].gameObject.SetActive(false);
                break;
            case 2:
                notesPanel.SetActive(true);
                notesText[0].gameObject.SetActive(false);
                notesText[1].gameObject.SetActive(false);
                notesText[2].gameObject.SetActive(true);
                break;
        }
        notesPanel.SetActive(true);
    }
    
    public void CloseButton()
    {
        
    }
    
}
