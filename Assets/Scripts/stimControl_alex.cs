using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO.Ports;
using System;

public class stimControl_alex : MonoBehaviour
{
    [SerializeField] objectTouch objectTouch;

    [SerializeField, Range(0, 1000)] int strengthThumbTip;
    [SerializeField, Range(0, 1000)] int strengthThumbBottom;
    [SerializeField, Range(0, 1000)] int strengthIndexTip;
    [SerializeField, Range(0, 1000)] int strengthIndexBottom;
    [SerializeField, Range(0, 1000)] int strengthMiddleTip;
    [SerializeField, Range(0, 1000)] int strengthMiddleBottom;
    [SerializeField, Range(0, 1000)] int strengthRingTip;
    [SerializeField, Range(0, 1000)] int strengthRingBottom;
    [SerializeField, Range(0, 1000)] int strengthPinkyTip;
    [SerializeField, Range(0, 1000)] int strengthPinkyBottom;
    [SerializeField, Range(0, 1000)] int strengthPalm;
    [SerializeField, Range(0, 1000)] int buttonStrength;
    [SerializeField, Range(50, 3000)] int pulseWidth;
    [SerializeField, Range(10, 150)] int frequency;
    [SerializeField] string port;
    [SerializeField] GameObject bear;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject texturePlane;


    private string serialport;
    //SerialPort stream;

    String message1;
    String message2;
    String message3;
    String wholeMessage;

    int[] contact;

    bool stimTrigger = false;
    bool calibThumbTip = false;
    bool calibThumbBottom = false;
    bool calibIndexTip = false;
    bool calibIndexBottom = false;
    bool calibMiddleTip = false;
    bool calibMiddleBottom = false;
    bool calibRingTip = false;
    bool calibRingBottom = false;
    bool calibPinkyTip = false;
    bool calibPinkyBottom = false;
    bool calibPalm = false;

    int finishCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        //pulseWidth = 400;
        //frequency = 100;
        //serialport = "\\\\.\\COM" + port;
        //try
        //{
        //    stream = new SerialPort(serialport, 115200);
        //    string[] ports = SerialPort.GetPortNames();

        //    Debug.Log("# Ports: " + ports.Length);
        //    for (int i = 0; i < ports.Length; i++)
        //    {
        //        Debug.Log(ports[i]);
        //    }

        //    stream.ReadTimeout = 50;
        //    stream.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        //    stream.Open();
        //}
        //catch (Exception e)
        //{

        //}

        contact = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    // Update is called once per frame
    void Update()
    {
        message1 = pulseWidth + "," + frequency + ",";
        message2 = strengthThumbTip + "," + strengthThumbBottom + "," + strengthIndexTip + ",0," + strengthMiddleTip + ",0," +
            strengthRingTip + ",0," + strengthPinkyTip + ",0,0," + strengthIndexBottom + ",0," + strengthMiddleBottom + ",0," +
            strengthRingBottom + ",0," + strengthPinkyBottom + ",0," + strengthPalm + ",";
        message3 = "";
        stimTrigger = false;

        if (objectTouch.thumbTip == true || calibThumbTip == true) { message3 += "1,"; stimTrigger = true; }
        else message3 += "0,";

        if (objectTouch.thumbBottom == true || calibThumbBottom == true) { message3 += "1,"; stimTrigger = true; }
        else message3 += "0,";

        if (objectTouch.indexTip == true || calibIndexTip == true) { message3 += "1,0,"; stimTrigger = true; }
        else message3 += "0,0,";

        if (objectTouch.middleTip == true || calibMiddleTip == true) { message3 += "1,0,"; stimTrigger = true; }
        else message3 += "0,0,";

        if (objectTouch.ringTip == true || calibRingTip == true) { message3 += "1,0,"; stimTrigger = true; }
        else message3 += "0,0,";

        if (objectTouch.pinkyTip == true || calibPinkyTip == true) { message3 += "1,0,0,"; stimTrigger = true; }
        else message3 += "0,0,0,";

        if (objectTouch.indexBottom == true || calibIndexBottom == true) { message3 += "1,0,"; stimTrigger = true; }
        else message3 += "0,0,";

        if (objectTouch.middleBottom == true || calibMiddleBottom == true) { message3 += "1,0,"; stimTrigger = true; }
        else message3 += "0,0,";

        if (objectTouch.ringBottom == true || calibRingBottom == true) { message3 += "1,0,"; stimTrigger = true; }
        else message3 += "0,0,";

        if (objectTouch.pinkyBottom == true || calibPinkyBottom == true) { message3 += "1,0,"; stimTrigger = true; }
        else message3 += "0,0,";

        if (objectTouch.palm == true || calibPalm == true) { message3 += "1"; stimTrigger = true; }
        else message3 += "0";

        if (stimTrigger) message1 += "1,";
        else message1 += "0,";

        wholeMessage = message1 + message2 + message3;
        //WriteToSerial(wholeMessage);

        //if ((mugTouch.mug == true && insideTouch.inside == false) || calibMug == true)
        //{
        //    stimTrigger = true;
        //    message1 = message1 + "1,";
        //    message3 = "0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
        //    wholeMessage = message1 + message2 + message3;
        //    WriteToSerial(wholeMessage);
        //}
        //else
        //{
        //    message1 = message1 + "0,";
        //    message3 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
        //    wholeMessage = message1 + message2 + message3;
        //    if (stimTrigger == true)
        //    {
        //        WriteToSerial(wholeMessage);
        //        stimTrigger = false;
        //    }
        //}

        if (Input.GetKeyDown("1")) calibThumbTip = !calibThumbTip;
        if (Input.GetKeyDown("2")) calibThumbBottom = !calibThumbBottom;
        if (Input.GetKeyDown("3")) calibIndexTip = !calibIndexTip;
        if (Input.GetKeyDown("4")) calibIndexBottom = !calibIndexBottom;
        if (Input.GetKeyDown("5")) calibMiddleTip = !calibMiddleTip;
        if (Input.GetKeyDown("6")) calibMiddleBottom = !calibMiddleBottom;
        if (Input.GetKeyDown("7")) calibRingTip = !calibRingTip;
        if (Input.GetKeyDown("8")) calibRingBottom = !calibRingBottom;
        if (Input.GetKeyDown("9")) calibPinkyTip = !calibPinkyTip;
        if (Input.GetKeyDown("0")) calibPinkyBottom = !calibPinkyBottom;
        if (Input.GetKeyDown("-")) calibPalm = !calibPalm;
        if (Input.GetKeyDown("space")) buttonActivation();
        if (Input.GetKeyDown("f")) finish();
            Debug.Log(wholeMessage);
        //Debug.Log(buttonStim);
    }

    void OnApplicationQuit()
    {
        wholeMessage = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
        //WriteToSerial(wholeMessage);
        Debug.Log(wholeMessage);
        //stream.Close();
    }

    public void WriteToSerial(string message)
    {
        //if (!stream.IsOpen) return;
        //stream.WriteLine(message);
        //stream.BaseStream.Flush();

    }

    public void buttonActivation()
    {
        message1 = pulseWidth + "," + frequency + ",2,";
        message2 = "0,0," + buttonStrength + "," + "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,";
        message3 = "0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
        wholeMessage = message1 + message2 + message3;
        //stream.WriteLine(wholeMessage);
        //stream.BaseStream.Flush();
        message1 = pulseWidth + "," + frequency + ",0,";
        message2 = "0,0," + buttonStrength + "," + "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,";
        message3 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
        wholeMessage = message1 + message2 + message3;
        //stream.WriteLine(wholeMessage);
        //stream.BaseStream.Flush();
    }

    //private static void DataReceivedHandler(
    //            object sender,
    //            SerialDataReceivedEventArgs e)
    //{
    //    SerialPort sp = (SerialPort)sender;
    //    string indata = sp.ReadExisting();
    //    Debug.Log("Data Received:");
    //    Debug.Log(indata);
    //}

    private void finish()
    {
        finishCounter++;
        if (finishCounter % 2 == 1)
        {
            bear.SetActive(false); button1.SetActive(false); button2.SetActive(false);
            texturePlane.SetActive(true);
        } else
        {
            bear.SetActive(true); button1.SetActive(true); button2.SetActive(true);
            texturePlane.SetActive(false);
        }
    }
}
