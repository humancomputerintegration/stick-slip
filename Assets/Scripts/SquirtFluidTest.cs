using UnityEngine;
using System.IO.Ports;
namespace Oculus.Interaction
{
    public class SquirtFluidTest : MonoBehaviour
    {
        [SerializeField, Range(0, 255)] int pump1PWM;
        [SerializeField, Range(0, 500)] int pump1Time;
        [SerializeField, Range(0, 255)] int pump2PWM;
        [SerializeField, Range(0, 500)] int pump2Time;
        [SerializeField] StickyInteractableDebugVisual stickyControl;
        [SerializeField] SlipInteractableDebugVisual slipControl;

        SerialPort sp;
        string pumpParams; float currentTime; float stickTime; float slipTime;

        // Use this for initialization
        void Start()
        {
            string the_com = "COM25"; // make this an entry field

            //foreach (string mysps in SerialPort.GetPortNames())
            //{
            //    print(mysps);
            //    if (mysps != "COM1") { the_com = mysps; break; }
            //}

            sp = new SerialPort("\\\\.\\" + the_com, 9600);

            if (!sp.IsOpen)
            {
                print("Opening " + the_com + ", baud 9600");
                sp.Open();
                sp.ReadTimeout = 100;
                sp.Handshake = Handshake.None;
                if (sp.IsOpen) { print("Open"); }
            }
        }

        // Update is called once per frame
        void Update()
        {
            //pumpParams = "<" + pump1PWM + "," + pump1Time + "," + pump2PWM + "," + pump2Time + ">";
            if (!sp.IsOpen)
            {
                sp.Open();
                print("opened sp");
            }
            if (sp.IsOpen)
            {
                currentTime = Time.time;

                if (stickyControl.stickyState && (currentTime - stickTime > 30 || stickTime < slipTime))
                {
                    pumpParams = "<" + pump1PWM + "," + pump1Time + "," + 0 + "," + 0 + ">";
                    print("Writing " + pumpParams);
                    sp.Write(pumpParams);
                    stickTime = Time.time;
                }

                if (slipControl.slipState && (currentTime - slipTime > 3 || slipTime < stickTime))
                {
                    pumpParams = "<" + 0 + "," + 0 + "," + pump2PWM + "," + pump2Time + ">";
                    print("Writing " + pumpParams);
                    sp.Write(pumpParams);
                    slipTime = Time.time;
                }
            }
        }
    }
}
