using UnityEngine;

public class AbstractEdibleObject : AbstractInteractableObject
{
    [Range(0f,1f)]
    public float foodWorth = 0.1f;
    [Range(0f,1f)]
    public float alcoholWorth = 0;
    public int scoreWorth = 1;


    public override void OnInteract()
    {
        base.OnInteract();
        if (GameVariables.cursesActive["Hunger"])
        {
            GameVariables.playerHunger = Mathf.Clamp01(GameVariables.playerHunger + foodWorth);
            GameVariables.playerScore += scoreWorth;
            Destroy(this.gameObject);
        }
        if (GameVariables.cursesActive["Drunk"])
        {
            GameVariables.playerDrunkenness = Mathf.Clamp01(GameVariables.playerDrunkenness + alcoholWorth);
            GameVariables.playerScore += scoreWorth;
            Destroy(this.gameObject);
        }
    }
}
