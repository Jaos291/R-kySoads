using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpiral : MonoBehaviour
{
    [SerializeField] private float rotateTime;

    [SerializeField] private bool rotateOnY;

    [SerializeField] private bool rotateOnX;
    // Start is called before the first frame update
    void Start()
    {
        RotateIndifinetly();
    }

    public void RotateIndifinetly()
    {
        if (rotateOnY)
        {
            LeanTween.rotateAroundLocal(this.gameObject, Vector3.up, 360f, rotateTime).setRepeat(-1);
        }

        if (rotateOnX)
        {
            LeanTween.rotateAroundLocal(this.gameObject, Vector3.back, 360f, rotateTime).setRepeat(-1);
        }
    }

}
