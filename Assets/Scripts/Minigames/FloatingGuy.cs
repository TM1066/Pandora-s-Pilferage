using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingGuy : MonoBehaviour
{
    public Rigidbody2D guysBody;
    public Image renderer;
    public List<Sprite> possibleSprite;

    void Start()
    {
        renderer.sprite = ScriptUtils.GetRandomFromList(possibleSprite);
        StartCoroutine(Bounce());
    }


    IEnumerator Bounce()
    {
        while (true)
        {
            guysBody.AddForce(new Vector2(Random.Range(-1000,1000), Random.Range(-1000,1000)));
            guysBody.angularVelocity += Random.Range(-10,10);
            yield return new WaitForSeconds(Random.Range(1,5));
        }
    }
}
