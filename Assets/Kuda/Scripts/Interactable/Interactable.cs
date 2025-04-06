using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptmessage;

    public void BaseInteract()
    {
        Interact();


    }

    protected virtual void Interact()
    {
        //to be overridden by sub classes wont contain code
    }
}