using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class AbstractChest : AbstractInteractableObject
{
    public string curseName;
    public TextMeshProUGUI curseNotifyText;

    public Color curseColour;
    public VisualEffect curseOrbVFX;
    public Renderer curseOrbRenderer;

    bool obtained = false;




    void Start()
    {
        curseOrbRenderer.material.color = curseColour;
        curseOrbVFX.SetVector4("Curse Colour", curseColour);
    }



    public virtual void CurseEffect()
    {
        StartCoroutine(ShowCurseNotification(2));
    }


    public override void OnInteract()
    {
        if (!obtained)
        {
            CurseEffect();
            obtained = true;

            base.OnInteract();
        }
    }


    IEnumerator ShowCurseNotification(float duration)
    {
        curseNotifyText.text = "Obtained the Curse of " + curseName;

        yield return new WaitForSeconds(3);

        curseNotifyText.text = "";
    }






}
