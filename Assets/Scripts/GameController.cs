using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;




    //------------------

    public bool CanPlay;

    private void Awake()
    {
        Instance = this;
    }
}
