using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public float timelineTick;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
