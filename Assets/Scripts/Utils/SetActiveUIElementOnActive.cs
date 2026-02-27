using UnityEngine;
using UnityEngine.EventSystems;

public class SetActiveUIElementOnActive : MonoBehaviour
{
    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    void OnDisable()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
