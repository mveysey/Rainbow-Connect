using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ChatManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public Player p1Move;
    public PhotonView photonView;
    public GameObject BubbleSpeechObject;
    public TextMeshPro UpdatedText;
    private InputField ChatInputField;
    private bool DisableSend;
    // Start is called before the first frame update
    private void Awake()
    {
        ChatInputField = GameObject.Find("ChatInputField").GetComponent<InputField>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (photonView.IsMine)
        {
            if(!DisableSend && ChatInputField.isFocused)
            {
                if(ChatInputField.text != "" && ChatInputField.text.Length >0 && Input.GetKeyDown(KeyCode.Period))
                {
                    photonView.RPC("SendMessage", Photon.Pun.RpcTarget.AllBuffered, ChatInputField.text);
                    BubbleSpeechObject.SetActive(true);
                    ChatInputField.text = "";
                    DisableSend = true;

                }
            }
        }
        
    }
    [PunRPC]
    private void SendMessage(string message)
    {
        UpdatedText.text = message;
        StartCoroutine("Remove");
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(4f);
        BubbleSpeechObject.SetActive(false);
        DisableSend = false;
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(BubbleSpeechObject.active);

        }
        else if (stream.IsReading)
        {
            BubbleSpeechObject.SetActive((bool)stream.ReceiveNext());
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
}
