using UnityEngine;

public class AbstractEdibleObject : AbstractInteractableObject
{
    [Range(0f,1f)]
    public float foodWorth = 0.1f;


    public override void OnInteract()
    {
        base.OnInteract();
        if (GameVariables.cursesActive["Hunger"])
        {
            GameVariables.playerHunger = Mathf.Clamp01(GameVariables.playerHunger + foodWorth);
            Destroy(this.gameObject);
        }
    }

    
}
