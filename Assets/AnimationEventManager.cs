using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.gm.StartRun();
    }
}
