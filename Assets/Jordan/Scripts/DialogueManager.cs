using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public DialogueSystem start;
    public string[] name;
    public DialogueInfo info;
    public string Nextscene;
    void Start()
    {
        if (info != null)
        {
            StartCoroutine(LoadDialogue());// creates a couritnne so data can load before dialogue is implemented
        }
        else
        {
            Debug.Log("info not assigned");
        }
    }

    // Update is called once per frame

    public IEnumerator LoadDialogue()
    {

        ;
        yield return StartCoroutine(info.LoadData());
        if (info.cutscene.Cuts != null || info.cutscene.Cuts.Count > 0) // will check if data is instatiated
        {
            StartCoroutine(Dialogue()); // will only start the dialogue sequence once all the data from the json file has been transfered 
        }
        else
        {
            Debug.Log("data still not loaded");
        }


    }

    public IEnumerator Dialogue()
    {
        for (int i = 0; i < name.Length; i++) // this will be made so many different characters can speak to each other
        {

            start.StartDialogue(name[i]);
            Debug.Log(i);
            while (!start.end) // if the end bool is still false this will freeze the loop so the Queue can finish in DialogueSystem
            {
                yield return null;
            }
            start.end = true;

            SkipDialogue(); // will go to the next scene once dialogue cutscene has finished 
        }



    }

    void SkipDialogue()
    {
        SceneManager.LoadScene(Nextscene);
    }
}
