﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    public Text PingText;
    private bool Off = false;
    public GameObject disconnectUI;
    public GameObject PlayerFeed;
    public GameObject FeedGrid;

    // Start is called before the first frame update
    private void Awake()
    {
        GameCanvas.SetActive(true);
    }
    private void Update()
    {
        CheckInput();
        PingText.text = "Ping " + PhotonNetwork.GetPing();
    }

    private void CheckInput()
    {
        if (Off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(false);
            Off = false;
        }
        else if (!Off && Input.GetKeyDown(KeyCode.Escape))
        {
            disconnectUI.SetActive(true);
            Off = true;
        }
        
    }
    public void SpawnPlayer()
    {


        float randomValue = Random.Range(-1f, 1f);
        print("spawn");

        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(this.transform.position.x*randomValue,this.transform.position.y,this.transform.position.z), Quaternion.identity,0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("MainMenu");
    }
    private void OnPhotonPlayerConnect(Photon.Realtime.Player player)
    {
        GameObject obj = Instantiate(PlayerFeed);
        obj.transform.SetParent(FeedGrid.transform, false);
        obj.GetComponent<Text>().text = player.NickName + "joined the game";
        
    }
    private void OnPhotonPlayerDisconnected(Photon.Realtime.Player player)
    {
        GameObject obj = Instantiate(PlayerFeed);
        obj.transform.SetParent(FeedGrid.transform, false);
        obj.GetComponent<Text>().text = player.NickName + "left the game";
        obj.GetComponent<Text>().color = Color.red;
    }
}