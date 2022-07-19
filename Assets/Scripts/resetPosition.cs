using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPosition : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;

    //[SerializeField] GameObject bear;

    void Start()
    {
        initialPosition = this.transform.position;
        initialRotation = this.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            initialPosition = this.transform.position;
            initialRotation = this.transform.rotation;
        }
    }

    public void reset()
    {
        //Vector3 position = this.transform.localPosition;
        //Quaternion rotation = this.transform.localRotation;

        //Vector3 rotationAngles = rotation.eulerAngles;

        //rotationAngles.y = rotationAngles.y - 90.0f;
        //rotation = Quaternion.Euler(rotationAngles);

        //this.transform.localPosition = position;
        //this.transform.localRotation = rotation;
        this.transform.position = initialPosition;
        this.transform.rotation = initialRotation;
    }
}
