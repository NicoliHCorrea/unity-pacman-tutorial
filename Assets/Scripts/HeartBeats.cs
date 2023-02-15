using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class HeartBeats : MonoBehaviour
{
    public SerialController serialController;
    // Start is called before the first frame update
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        InvokeRepeating(nameof(getBPM), 0f, 0.25f);

    }


    void getBPM()
    {
        string message = serialController.ReadSerialMessage();
        DateTime d = System.DateTime.Now;
        LogFile.instance.heartBeats.Add(d + "BPM: " + message);

    }
}
