using UnityEngine;

public class Gem : MonoBehaviour
{
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.g, sr.color.a - Time.deltaTime*0.4f);
        if(sr.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
