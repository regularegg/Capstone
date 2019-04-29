using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ThreadTest : MonoBehaviour
{
    // 1. Declare Variables
    Thread receiveThread; //1
    UdpClient client; //2
    int port; //3

    public GameObject boat;

    public Text textShow;

    private string outputShow;
//add keyboard or some sort of UI to change numbers in game
    public float xLowerBound = 53;
    public float xUpperBound = 1073;

    public float yLowerBound = 125;
    public float yUpperBound = 605;


    public static ThreadTest TT;
    //This will take the string from Python and turn it into 2 floats.
    //Then it will call mover(turns floats into vector3) in updateposition to update position.
    private string _textthing;
    public string TextThing
    {
        get { return _textthing; }
        set
        {
            float[] fValues = Array.ConvertAll(value.Split(','), float.Parse);
            if (fValues.Length == 2)
            {
                Debug.Log("updating poss!!!!!");
                UpdatePosition(mover(fValues[0],fValues[1]));
            }
            else
            {
                Debug.Log("Couldn't execute update position");
            }
            _textthing = value;
        }
    }

    private string holder;

    Vector3 mover(float x, float y)
    {
        float mappedX = Mathf.Lerp(-5, 5, Mathf.InverseLerp(xUpperBound, xLowerBound, x));
        float mappedY = Mathf.Lerp(-5, 5, Mathf.InverseLerp(yUpperBound, yLowerBound, y));
        
        
        Vector3 output = new Vector3(mappedX, mappedY);
       // Vector3 output = new Vector3(x, y);
        return output;
    }
    
    
    void UpdatePosition(Vector3 pos)
    {
        Debug.Log("boat is update positioning");
        boat.transform.position = pos;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        port = 5065; //1 
        InitUDP(); //4
        boat = GameObject.Find("toot the turt");
        outputShow = "0,0";
        
        if (TT == null)
        {
            TT = this;
        }
        else if(TT != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
    
    // 3. InitUDP
    private void InitUDP()
    {
        print ("UDP Initialized");

        
        receiveThread = new Thread (new ThreadStart(ReceiveData)); //1 
        receiveThread.IsBackground = true; //2
        receiveThread.Start (); //3

    }

    // 4. Receive Data
    private void ReceiveData()    
    {
        client = new UdpClient (port); //1
        while (true) //2
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port); //3
                byte[] data = client.Receive(ref anyIP); //4

                string output = Encoding.UTF8.GetString(data); //5
                //Debug.Log(output);
                outputShow = output;
                holder = output;
                //print (">> " + output);

            } catch(System.Exception e)
            {
                print (e.ToString()); //7
            }
        }
        
        
    }

    
    
    // Update is called once per frame
    void Update()
    {
        //textShow.text = outputShow;
        TextThing = outputShow;
    }
    
    
    
}
