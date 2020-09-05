using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _playerPosition, Quaternion _playerRotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _playerPosition, _playerRotation);
        }
        else
        {
            _player = Instantiate(playerPrefab, _playerPosition, _playerRotation);
        }

        _player.GetComponent<PlayerManager>().id = _id; 
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id,_player.GetComponent<PlayerManager>());
    }
}
