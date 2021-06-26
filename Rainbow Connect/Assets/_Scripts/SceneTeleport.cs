using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class SceneTeleport : MonoBehaviour
{
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        if (gameObject.CompareTag("dance"))
        {
            PhotonNetwork.LoadLevel("DanceRoom");
        }
        if (gameObject.CompareTag("movie"))
        {
            PhotonNetwork.LoadLevel("MovieRoom");
        }
        if (gameObject.CompareTag("museum"))
        {
            PhotonNetwork.LoadLevel("MuseumRoom");
        }
    }
}
