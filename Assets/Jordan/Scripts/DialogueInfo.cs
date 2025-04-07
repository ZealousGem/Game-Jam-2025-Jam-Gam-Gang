using UnityEngine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Windows;

public class DialogueInfo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    public CutsceneData cutscene = new CutsceneData();


    public IEnumerator LoadData()
    {

        string filepath = Path.Combine(Application.streamingAssetsPath, "Dialogue.txt"); // will find Json file through the streaming assets folder 

        if (System.IO.File.Exists(filepath)) // checks if the the josn file exisits 
        {
            string DialogueD = System.IO.File.ReadAllText(filepath);

            // uses a couritne to load data so it isn't null errored

            if (!string.IsNullOrEmpty(DialogueD)) // will check if data in josn file isn't null
            {
                cutscene = JsonUtility.FromJson<CutsceneData>(DialogueD); // converts the json data to the variables in dialogueData
                Debug.Log("successfully loaded");
            }

            else
            {
                Debug.Log("Dialogue data not successfully loaded.");
            }

        }

        else
        {
            Debug.Log("File is missing");
        }

        yield return null; // will return null if not file was found 

    }
}

[System.Serializable]
public class CutsceneData
{
    public List<CutsceneNos> Cuts;
}

[System.Serializable]
public class CutsceneNos
{
    public string id;
    public List<StoryText> Text;
    public List<StoryImages> images;
}

[System.Serializable]
public class StoryText
{
   public  string texts;
   
}

[System.Serializable]
public class StoryImages
{

    public string imageNo;
}
