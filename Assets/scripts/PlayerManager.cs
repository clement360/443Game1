using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance = null;

    public GameObject player;
    public int playerPosX;
    public int playerPosY;
    public GameObject playerObject;

    // Use this for initialization
    void Start () {
        playerObject = (GameObject)Instantiate(player, new Vector3(-8f, 0, 0), Quaternion.identity) as GameObject;
        playerPosX = -8;
        playerPosY = 0;

        instance = this;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
