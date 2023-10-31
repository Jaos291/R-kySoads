using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    //------------------

    public bool CanPlay;

    [SerializeField] private GameObject _victory;

    private void Awake()
    {
        Instance = this;
    }
}
