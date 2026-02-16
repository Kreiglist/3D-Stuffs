using UnityEngine;

public class DebugInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        DoSomething();
    }
    void DoSomething()
    {
        Debug.Log("It did something.");
    }
}
