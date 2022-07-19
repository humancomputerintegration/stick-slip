using System;
using OculusSampleFramework;
using UnityEngine;


public class mugTouch : MonoBehaviour
{
    public bool mugIndexTip = false;

    void Update()
    {
        //Debug.Log(mug);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "b_r_index3_CapsuleCollider") mugIndexTip = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "b_r_index3_CapsuleCollider") mugIndexTip = false;
    }
}
