using UnityEngine;
using UnityEngine.Events;

public class AbstractInteractableObject : MonoBehaviour
{

    public string displayName;
    public UnityEvent interactEvents;



    public void Interact()
    {
        interactEvents.Invoke();
        OnInteract();
    }

    public virtual void OnInteract()
    {
        
    }
}
