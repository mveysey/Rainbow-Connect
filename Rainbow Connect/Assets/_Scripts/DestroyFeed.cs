using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class DestroyFeed : MonoBehaviourPunCallbacks
{
    public float DestroyTime = 4f;

    private void OnEnable()
    {
        Destroy(gameObject, DestroyTime);
    }
}
