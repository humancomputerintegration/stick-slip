using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insideTouch : MonoBehaviour
{
    public bool insideIndexTip = false;

    void Update()
    {
        //Debug.Log(inside);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "b_r_index3_CapsuleCollider") insideIndexTip = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "b_r_index3_CapsuleCollider") insideIndexTip = false;
    }
}
