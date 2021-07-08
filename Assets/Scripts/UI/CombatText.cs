using UnityEngine;
using TMPro;

public class CombatText : MonoBehaviour
{
    public float fadeOutRate;
    public float floatSpeed;
    public TMP_Text spellName;
    private CanvasGroup cg;

    private Vector3 startPos;
    public bool isTemporary;
    private bool active;

    private void Awake()
    {
        active = false;
        startPos = transform.position;
        cg = GetComponent<CanvasGroup>();    
    }

    private void Update()
    {
        if (active)
        {
            transform.position += (Vector3)Vector2.up * floatSpeed;
            cg.alpha -= Time.deltaTime * fadeOutRate;
            if (isTemporary && cg.alpha <= 0) Destroy(gameObject);
        }
    }

    public void UpdateSpellText(string s)
    {
        SetText(s);
        cg.alpha = 1;
        active = true;
    }


    public void CreateCombatTextRequest(string s, float fontSize, bool istemp)
    {
        SetText(s);
        spellName.enableAutoSizing = false;
        spellName.fontSize = fontSize;
        cg.alpha = 0;
    }

    public void ActivateRequest()
    {
        cg.alpha = 1;
        active = true;
    }

    private void SetText(string s)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-15, 15)));
        transform.position = startPos;
        spellName.text = s;
    }
}
