using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class PushToTalk : MonoBehaviourPun
{
    // Using p for now, but that can be changed if p is needed for something else
    public KeyCode PushButton = KeyCode.P;
    public Recorder VoiceRecorder;
    private PhotonView view;

    void Start()
    {
        view = photonView;
        
        // Make the microphone audio disabled upon joining (only enable it when PushButton is pressed)
        VoiceRecorder.TransmitEnabled = false;
    }

    void Update()
    {
        // If someone pushes down the button to talk, then their microphone audio will be transmitted
        if (Input.GetKeyDown(PushButton))
        {
            if (view.IsMine)
            {
                VoiceRecorder.TransmitEnabled = true;
            }
        }

        // If the button is not being pressed/just released then the microphone audio is disabled 
        else if (Input.GetKeyUp(PushButton))
        {
            if (view.IsMine)
            {
                VoiceRecorder.TransmitEnabled = false;
            }
        }
    }
}
