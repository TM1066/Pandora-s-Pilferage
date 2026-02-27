using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public AbstractInteractableObject currentlySelected = null;

    public float interactDistance = 30;

    public TextMeshProUGUI objectDisplayText;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (currentlySelected) currentlySelected.Interact();
    }


    // Update is called once per frame
    void Update()
    {
        if (currentlySelected) objectDisplayText.text = currentlySelected.displayName;
        else objectDisplayText.text = "";

        var cameraTrans = Camera.main.transform;
        Ray ray = new Ray(cameraTrans.position, cameraTrans.forward);

        if (Physics.Raycast(ray,  out RaycastHit hit,interactDistance, ~LayerMask.GetMask("Ignore Raycast")))
        {
            if (hit.transform.gameObject.TryGetComponent(out AbstractInteractableObject obj))
            {
                currentlySelected = obj;
            }
        }
    
        else
        {
            currentlySelected = null;
            objectDisplayText.text = string.Empty;
        }
    }
}
