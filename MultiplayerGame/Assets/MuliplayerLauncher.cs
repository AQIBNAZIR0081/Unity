using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;

public class MuliplayerLauncher : MonoBehaviourPunCallbacks
{
    public PhotonView player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Lobby Successfully");
        PhotonNetwork.Instantiate(player.name, Vector3.zero, Quaternion.identity, 0);
    }
}
