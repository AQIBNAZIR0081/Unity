using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

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
        PhotonNetwork.Instantiate(player.gameObject.name, Vector3.zero, Quaternion.identity, 0);
    }
}
