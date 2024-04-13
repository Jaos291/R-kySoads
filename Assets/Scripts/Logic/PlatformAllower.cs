using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAllower : MonoBehaviour
{
    [SerializeField] private GameObject thisGameObject;
    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            thisGameObject.SetActive(false);
        }
    }
}
