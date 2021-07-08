using UnityEngine;
using TMPro;

public class CombatText : MonoBehaviour
{
    public float fadeOutRate;
    public float floatSpeed;
    public TMP_Text spellName;
    private CanvasGroup cg;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
        cg = GetComponent<CanvasGroup>();    
    }

    private void Update()
    {
        transform.position += (Vector3)Vector2.up * floatSpeed;
        cg.alpha -= Time.deltaTime * fadeOutRate;
    }

    public void UpdateSpellText(string s)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-15, 15)));
        transform.position = startPos;
        cg.alpha = 1;
        spellName.text = s + "!";
    }
}
