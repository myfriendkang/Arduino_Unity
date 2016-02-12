using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arduino_Unity : MonoBehaviour
{

    public string string_Yellow = "COM4";
    public string string_Brownn = "COM3";
    public SerialPort sp;
    public SerialPort sp2;

    void OnGUI()
    {

        string_Brownn = GUI.TextField(new Rect(60, 45, 100, 25), string_Brownn);
        string_Yellow = GUI.TextField(new Rect(180, 45, 100, 25), string_Yellow);

        if (GUI.Button(new Rect(290, 45, 100, 25), "Connect"))
        {
            Controller.spsp = new SerialPort(string_Brownn, 9600);
            Controller.spsp2 = new SerialPort(string_Yellow, 9600);

            if (Controller.spsp.IsOpen && Controller.spsp2.IsOpen)
            {
                Controller.spsp.Close();
                Controller.spsp2.Close();
                print("Serial port is opened, so closed!");
            }
            else {
                Controller.spsp.Open();
                Controller.spsp2.Open();
                Controller.spsp.ReadTimeout = 1;
                Controller.spsp2.ReadTimeout = 1;
            }

            Application.LoadLevel("Start");
        }
        else {
            Debug.Log("WRONG PORT");
        }

        if (GUI.Button(new Rect(190, 80, 120, 25), "Anyway Play"))
        {

            Application.LoadLevel("Start");
        }

    }
}
