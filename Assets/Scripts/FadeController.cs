using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class FadeController : MonoBehaviour
{
    [SerializeField] private GameObject _fadeIn;

    [SerializeField] private GameObject _fadeOut;

    // Start is called before the first frame update
    public void FadeIn()
    {
        _fadeOut.SetActive(false);
        _fadeIn.SetActive(true);
    }

    public void FadeOut()
    {
        _fadeOut.SetActive(true);
        _fadeIn.SetActive(false);
    }
}
