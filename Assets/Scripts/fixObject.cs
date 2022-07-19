using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixObject : MonoBehaviour
{
    [SerializeField] GameObject pose1;
    //[SerializeField] GameObject pose2;
    //[SerializeField] GameObject pose3;
    //[SerializeField] GameObject pose4;
    //[SerializeField] GameObject pose5;
    //[SerializeField] GameObject pose6;
    [SerializeField] GameObject fixText;
    [SerializeField] GameObject unfixText;

    int counter = 0;

    //[SerializeField] GameObject bear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void fix()
    {
        //Vector3 position = this.transform.localPosition;
        //Quaternion rotation = this.transform.localRotation;

        //Vector3 rotationAngles = rotation.eulerAngles;

        //rotationAngles.y = rotationAngles.y + 90.0f;
        //rotation = Quaternion.Euler(rotationAngles);

        //this.transform.localPosition = position;
        //this.transform.localRotation = rotation;

        counter++;
        counter %= 2;
        if (counter == 1)
        {
            pose1.SetActive(false); //pose2.SetActive(false); //pose3.SetActive(false); pose4.SetActive(false); pose5.SetActive(false); pose6.SetActive(false);
            fixText.SetActive(false); unfixText.SetActive(true);
        }
        else
        {
            pose1.SetActive(true); //pose2.SetActive(true); //pose3.SetActive(true); pose4.SetActive(true); pose5.SetActive(true); pose6.SetActive(true);
            fixText.SetActive(true); unfixText.SetActive(false);
        }
    }
}
