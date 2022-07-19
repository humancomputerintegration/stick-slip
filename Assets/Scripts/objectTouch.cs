using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTouch : MonoBehaviour
{
    public bool thumbTip = false;
    public bool thumbBottom = false;
    public bool indexTip = false;
    public bool indexBottom = false;
    public bool middleTip = false;
    public bool middleBottom = false;
    public bool ringTip = false;
    public bool ringBottom = false;
    public bool pinkyTip = false;
    public bool pinkyBottom = false;
    public bool palm = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "b_r_thumb3_CapsuleCollider") thumbTip = true;
        if (other.gameObject.name == "b_r_thumb2_CapsuleCollider") thumbBottom = true;
        if (other.gameObject.name == "b_r_index3_CapsuleCollider") indexTip = true;
        if (other.gameObject.name == "b_r_index2_CapsuleCollider") indexBottom = true;
        if (other.gameObject.name == "b_r_middle3_CapsuleCollider") middleTip = true;
        if (other.gameObject.name == "b_r_middle2_CapsuleCollider") middleBottom = true;
        if (other.gameObject.name == "b_r_ring3_CapsuleCollider") ringTip = true;
        if (other.gameObject.name == "b_r_ring2_CapsuleCollider") ringBottom = true;
        if (other.gameObject.name == "b_r_pinky3_CapsuleCollider") pinkyTip = true;
        if (other.gameObject.name == "b_r_pinky2_CapsuleCollider") pinkyBottom = true;
        if (other.gameObject.name == "r_palm_center_CapsuleCollider") palm = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "b_r_thumb3_CapsuleCollider") thumbTip = false;
        if (other.gameObject.name == "b_r_thumb2_CapsuleCollider") thumbBottom = false;
        if (other.gameObject.name == "b_r_index3_CapsuleCollider") indexTip = false;
        if (other.gameObject.name == "b_r_index2_CapsuleCollider") indexBottom = false;
        if (other.gameObject.name == "b_r_middle3_CapsuleCollider") middleTip = false;
        if (other.gameObject.name == "b_r_middle2_CapsuleCollider") middleBottom = false;
        if (other.gameObject.name == "b_r_ring3_CapsuleCollider") ringTip = false;
        if (other.gameObject.name == "b_r_ring2_CapsuleCollider") ringBottom = false;
        if (other.gameObject.name == "b_r_pinky3_CapsuleCollider") pinkyTip = false;
        if (other.gameObject.name == "b_r_pinky2_CapsuleCollider") pinkyBottom = false;
        if (other.gameObject.name == "r_palm_center_CapsuleCollider") palm = false;
    }
}
