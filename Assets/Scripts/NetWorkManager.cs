using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetWorkManager : MonoBehaviour
{
    public GameObject Player;
    private PhotonView photonV;
    private void Awake()
    {
        photonV = GetComponent<PhotonView>();   
        GameObject NewPlayer = PhotonNetwork.Instantiate(Player.name, new Vector2(Random.Range(-28.5f, 28.5f), Random.Range(-19f, 19f)), Quaternion.identity);
        if (!photonV.IsMine)
        {
            NewPlayer.GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }
    }
}
